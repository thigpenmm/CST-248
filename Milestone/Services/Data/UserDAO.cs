using Minesweeper.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Minesweeper.Services.Data
{
    public class UserDAO
    {
        // Establish DB Connection
        string dbconn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Minesweeper;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool findByUser(User user)
        {

            bool result = false;

            try
            {
                // String parameters 
                string query = "SELECT * FROM dbo.Users WHERE USERNAME=@USERNAME AND PASSWORD=@PASSWORD";
                using (SqlConnection cn = new SqlConnection(dbconn))
                using (SqlCommand cmd = new SqlCommand(query, cn))

                {
                    // Parameters values
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = user.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = user.Password;

                    // Open connection
                    cn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read results
                    if (reader.HasRows)
                    {

                        // if user exists
                        result = true;
                    }
                    else
                    {
                        // if user doesn't exist
                        result = false;
                    }
                    cn.Close();
                }
                //return the result of findByUser
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public bool Register(User user)
        {

            bool result = false;

            try
            {
                // Prepare the INSERT statement
                string query = "INSERT INTO dbo.Users (USERNAME, PASSWORD, FIRSTNAME, LASTNAME, SEX, EMAIL, AGE, STATE) VALUES (@Username, @Password, @FirstName, @LastName, @Sex, @Email, @Age, @State)";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection(dbconn))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    //Parameters values
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = user.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = user.Password;
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = user.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = user.LastName;
                    cmd.Parameters.Add("@Sex", SqlDbType.NVarChar, 50).Value = user.Sex;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = user.Email;
                    cmd.Parameters.Add("@Age", SqlDbType.Int).Value = user.Age;
                    cmd.Parameters.Add("@State", SqlDbType.NVarChar, 50).Value = user.State;

                    // Open the connection and execute the insert method
                    cn.Open();
                    var rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                        result = true;
                    else
                        result = false;
                    cn.Close();
                }

            }
            catch (SqlException e)
            {

                throw e;
            }

            // Return result of register
            return result;
        }
    }
}
