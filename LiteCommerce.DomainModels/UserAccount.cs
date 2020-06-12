using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// Lưu thông tin  liên quan đến tài khoản đăng nhập
    /// </summary>
    public class UserAccount
    {
        public string UserID { get; set; }
        public string FullName { get; set; }

        public string Title { get; set; }
        /// <summary>
        /// Ảnh user
        /// </summary>
        public string Photo { get; set; }

        public string GroupName { get; set; }
    }
}
