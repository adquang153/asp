using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers.SQLServer
{
    public class EmployeeUserAccountDAL : IUserAccountDAL
    {
        private string connectionString;

        public EmployeeUserAccountDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public UserAccount Authorize(string userName, string password)
        {
            //return new UserAccount()
            //{
            //    UserID = userName,
            //    FullName = "Quang Lê",
            //    Photo = "user.png",
            //    Title = "Sale Manager",
            //};
            UserAccount data = null;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT EmployeeID, LastName, FirstName, Title, Roles, PhotoPath FROM Employees WHERE Email=@userName AND Password =@password";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@password", password);
                using(SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dbReader.Read())
                    {
                        data = new UserAccount()
                        {
                            UserID = Convert.ToString(dbReader["EmployeeID"]),
                            FullName = Convert.ToString(dbReader["LastName"]) + " " + Convert.ToString(dbReader["FirstName"]),
                            Title = Convert.ToString(dbReader["Title"]),
                            Photo = Convert.ToString(dbReader["PhotoPath"]),
                            GroupName = Convert.ToString(dbReader["Roles"]),
                        };
                    }
                }
                connection.Close();
            }
            return data;
        }
    }
}
