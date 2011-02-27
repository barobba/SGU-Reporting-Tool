using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SGU_Reporting_Tool
{
    class ReportFactory
    {
        private int _numTotal = 0;

        public void GetTotalStudentCount(string yearTermCode, ref SqlConnection connection)
        {
            string cmdStr = "SELECT COUNT(*) FROM [" + Program.WorkingDB +
                "].[dbo].[" + Program.StudTermSumDivTable +
                "] WHERE CONVERT(numeric, [YR_CDE] + [TRM_CDE]) = " +
                yearTermCode + " AND [NUM_OF_CRS] > 0;";
            SqlCommand cmd = new SqlCommand(cmdStr);
            cmd.Connection = connection;

            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
                _numTotal = reader.GetInt32(0);
            reader.Close();
        }

        public ITableLayoutRowItem NewReport(string yearTermCode, ref SqlDataReader reader, ref SqlConnection connection)
        {
            switch (reader["Type"].ToString())
            {
                case "Verification":
                    {
                        string verfCmd = reader["Command"].ToString();
                        verfCmd = verfCmd.Replace("[TmsEPly]", "[" + Program.WorkingDB + "]");
                        verfCmd = verfCmd.Replace(":From_Year", "'" + yearTermCode.Substring(0, 4) + "'");
                        verfCmd = verfCmd.Replace(":To_Year", "'" + yearTermCode.Substring(0, 4) + "'");
                        verfCmd = verfCmd.Replace(":Cutoff_Year", "'" + yearTermCode.Substring(0, 4) + "'");
                        verfCmd = verfCmd.Replace(":From_Term", "'" + yearTermCode.Substring(4, 2) + "'");
                        verfCmd = verfCmd.Replace(":To_Term", "'" + yearTermCode.Substring(4, 2) + "'");
                        verfCmd = verfCmd.Replace(":Cutoff_Term", "'" + yearTermCode.Substring(4, 2) + "'");
                        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM (" + verfCmd + ");");
                        cmd.Connection = connection;
                        SqlDataReader missingReader = cmd.ExecuteReader();
                        int numMissing = _numTotal;
                        if (missingReader.Read())
                            numMissing = missingReader.GetInt32(0);
                        missingReader.Close();

                        VerificationReport rpt = new VerificationReport(
                            reader["Title"].ToString(),
                            numMissing, _numTotal,
                            reader["Library"].ToString(),
                            reader["Item"].ToString());
                        return rpt;
                    }
            }

            return null;
        }
    }
}
