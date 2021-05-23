using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Library;
using System.Threading;

namespace TAP_Library_WinForms
{
    static class Program
    {
        public static WorkCollection Library = new WorkCollection();
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //X.ADO.RunSQLServerInstance("MSSQL$AMBRATOLM_SQL");

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Main());
        }

        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
    }
}
