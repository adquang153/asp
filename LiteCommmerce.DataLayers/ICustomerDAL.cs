using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface ICustomerDAL
    {
        /// <summary>
        /// Hiển thị DS Customer, phân trang và có thể tìm kiếm
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchvalue"></param>
        /// <returns></returns>
        List<Customer> List(int page, int pageSize, string searchValue, string country);
        /// <summary>
        /// Đếm số lượng kết quả tìm kiếm được
        /// </summary>
        /// <param name="searchvalue"></param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// Lấy dữ liệu của 1 Customer dựa vào ID
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        Customer Get(string customerID);
        /// <summary>
        /// Bổ sung 1 Customer, hàm trả về ID của Customer đã bổ sung
        /// Nếu lỗi trả về giá trị nhỏ hơn hoặc bằng 0
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string Add(Customer data);
        /// <summary>
        /// Cập nhật dữ liệu 1 Customer
        /// Hàm trả về true nếu thành công và false nếu thất bại
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Customer data);
        /// <summary>
        /// Xóa những Customer được chọn
        /// Hàm trả về số Customer đã xóa được
        /// </summary>
        /// <param name="CustomerIDs"></param>
        /// <returns></returns>
        int Delete(string[] customerIDs);
    }
}
