using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGU_Reporting_Tool
{
    interface ITableLayoutRowItem
    {
        Control ControlAt(int column);
    }
}
