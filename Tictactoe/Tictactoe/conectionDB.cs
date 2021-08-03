using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tictactoe
{
    class conectionDB
    {


        string strconn = "Data Source=FRANCO-PC; Initial Catalog=tictactoe; Integrated Security=True";
        public SqlConnection connectionDB = new SqlConnection();

        public conectionDB()
        {
            connectionDB.ConnectionString = strconn;
        }

        public void Open()
        {
            try
            {
                connectionDB.Open();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have successfully connected! Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed to Connect!! {ex.Message}");
                Console.ResetColor();
            }
        }

        public void Close()
        {
            connectionDB.Close();
        }


    }
}
