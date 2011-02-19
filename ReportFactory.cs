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

        public void GetTotalStudentCount(string yearSemesterCode, ref SqlConnection connection)
        {
            string cmdStr = "SELECT COUNT(*) FROM [" + Program.WorkingDB +
                "].[dbo].[" + Program.StudTermSumDivTable +
                "] WITH CONVERT(integer, [YR_CDE] + [TRM_CDE]) = " +
                yearSemesterCode + ";";
            SqlCommand cmd = new SqlCommand(cmdStr);
            cmd.Connection = connection;

            _numTotal = cmd.ExecuteReader().GetInt32(0);
        }

        public ITableLayoutRowItem NewReport(ref SqlDataReader reader, ref SqlConnection connection)
        {
            switch (reader["ReportType"].ToString())
            {
                case "Verification":
                    {
                        SqlCommand cmd = new SqlCommand(reader["View"].ToString());
                        cmd.Connection = connection;
                        int numMissing = cmd.ExecuteReader().GetInt32(0);

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
