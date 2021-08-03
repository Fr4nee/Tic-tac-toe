using System;
using System.Data.SqlClient;
using System.Data;

namespace Tictactoe
{
    public class ConnectionDB
    {
        string strconn = "Data Source=FRANCO-PC; Initial Catalog=tictactoe; Integrated Security=True";
        public SqlConnection conDB = new SqlConnection();

        public SqlCommand cmd = new SqlCommand();

        public ConnectionDB()
        {
            conDB.ConnectionString = strconn;
        }

        public void Openn()
        {
            try
            {
                conDB.Open();
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

        public void UpdateMovement(int row, string column, string player)
        {
            try
            {
                using (SqlConnection connectionDB = new SqlConnection(strconn))
                {
                    conDB.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_movement", conDB);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@row", SqlDbType.NVarChar).Value = row ;
                    cmd.Parameters.AddWithValue("@column", SqlDbType.NVarChar).Value = column;
                    cmd.Parameters.AddWithValue("@player", SqlDbType.NVarChar).Value = player;
                    cmd.ExecuteNonQuery();
                    conDB.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RestartGame()
        {
            try
            {
                using (SqlConnection connectionDB = new SqlConnection(strconn))
                {
                    conDB.Open();
                    SqlCommand cmd = new SqlCommand("sp_restart_game", conDB);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    conDB.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            conDB.Close();
        }
    }

}

