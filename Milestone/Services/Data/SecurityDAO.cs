using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Minesweeper.Services.Data
{
    public class SecurityDAO
    {
        public bool FindByUser(UserModel user)
        {
            // Establish DB Connection
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            string username = user.Username;
            string password = user.Password;
            Console.WriteLine("user.Username: " + username);
            Console.WriteLine("user.Password: " + password);

            // String parameters 
            string queryString = @"SELECT * FROM dbo.Users WHERE USERNAME = '" + username + "' AND PASSWORD = '" + password + "'";

            bool loginSuccess = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create command objects
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = queryString;

                // Open connection
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Read results
                if (reader.Read())
                {
                    loginSuccess = true;
                }
                else
                {
                    loginSuccess = false;
                }
                return loginSuccess;
            }
        }
    }
}