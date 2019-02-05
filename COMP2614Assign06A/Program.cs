using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Bobby Gill - A00913705 COMP2614 Assign06D
/// Program that shows examples of querying an SQL server, displaying the data in a Windows Form (datagridview), 
/// a dialog, message box, validation layer, lambda expressions, C.R.U.D operations, using a class library, code separation, 
/// regular expressions, and other fun stuff!
/// </summary>

namespace COMP2614Assign06B
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
