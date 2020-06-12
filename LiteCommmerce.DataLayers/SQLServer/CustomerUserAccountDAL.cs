using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers.SQLServer
{
    public class CustomerUserAccountDAL : IUserAccountDAL
    {
        private string connectionString;

        public CustomerUserAccountDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public UserAccount Authorize(string userName, string password)
        {
            return new UserAccount()
            {
                UserID = userName,
                FullName = "Quangg",
                Photo = "user.png",
                Title = "Sale Manager",
            };
        }

        public int CheckAuthen(string email, string pass)
        {
            throw new NotImplementedException();
        }
    }
}
