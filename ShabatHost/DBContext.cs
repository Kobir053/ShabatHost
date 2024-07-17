using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ShabatHost
{
    public class DBContext
    {
        private string _connectionString {  get; set; }

        // constructor - gets the connection string to database
        public DBContext(string conn)
        {
            if (string.IsNullOrEmpty(conn))
                throw new ArgumentNullException(nameof(conn));
            _connectionString = conn;
        }

        // applies the query - inserts, and return the number of rows affected - if returns -1 it means something went wrong
        public int ExecuteNonQuery(string queryStr, params SqlParameter[] param)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(queryStr, connection))
            {
                if(param != null)
                    command.Parameters.AddRange(param);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    rowsAffected = -1;
                }
            }
            return rowsAffected;
        }

        // applies the query - selects, and return the dataTable with necessary information
        public DataTable MakeQuery(string queryStr, params SqlParameter[] param)
        {
            DataTable output = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(queryStr, connection))
            {
                if (param != null)
                    command.Parameters.AddRange(param);

                try
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(output);
                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine("An error occurred: " + ex.Message);
                }
            }
            return output;
        }

        // applies the query - select for one value, and returns it - if returns -1 it means something went wrong
        public int ExecScalar(string queryStr, params SqlParameter[] param)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(queryStr, connection))
            {
                if (param != null)
                    command.Parameters.AddRange(param);
                try
                {
                    connection.Open();
                    res = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("an error occured: " + ex.Message);
                    res = -1;
                }
            }
            return res;
        }
    }
}
