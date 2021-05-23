using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.ServiceProcess;

namespace X
{
    public static class ADO
    {
        private static string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
                connectionStringBuilder.DataSource = @".\AMBRATOLM_SQL";
                connectionStringBuilder.InitialCatalog = "LibraryDb";
                connectionStringBuilder.IntegratedSecurity = true;
                return connectionStringBuilder.ConnectionString;
            }
        }
        private static SqlConnection connection = new SqlConnection(ConnectionString);
        public class CommandedTable
        {
            public DataTable DataTable;
            public string CommandText;
        }

        public static void RunSQLServerInstance(string instanceName)
        {
            using (ServiceController service = new ServiceController(instanceName))
            {
                if (service.Status != ServiceControllerStatus.Running)
                {
                    service.Start();
                }
            }
        }

        public static CommandedTable GetTable(string commandText, string tableName = "")
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(commandText, connection);
                DataTable table = new DataTable(tableName);
                CommandedTable cTable = new CommandedTable();
                adapter.Fill(table);
                cTable.CommandText = commandText;
                cTable.DataTable = table;
                return cTable;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static int SetTable(CommandedTable ctable)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(ctable.CommandText, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                return adapter.Update(ctable.DataTable);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
