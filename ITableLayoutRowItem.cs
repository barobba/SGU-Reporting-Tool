using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGU_Reporting_Tool
{
    interface ITableLayoutRowItem
    {
        public object controlAt(int column);
    }
}
