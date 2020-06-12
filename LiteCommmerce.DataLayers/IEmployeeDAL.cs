using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IEmployeeDAL
    {
        /// <summary>
        /// Hiển thị DS Employee, phân trang và có thể tìm kiếm
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Employee> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// Đếm số lượng kết quả tìm kiếm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// Lấy dữ liệu của 1 Employee dựa vào ID
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        Employee Get(int EmployeeID);
        /// <summary>
        /// Bổ sung 1 Employee, hàm trả về ID của Employee đã bổ sung
        /// Nếu lỗi trả về giá trị nhỏ hơn hoặc bằng 0
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Employee data);
        /// <summary>
        /// Cập nhật dữ liệu 1 Employee
        /// Hàm trả về true nếu thành công và false nếu thất bại
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Employee data);
        /// <summary>
        /// Xóa những Employee được chọn
        /// Hàm trả về số Employee đã xóa được
        /// </summary>
        /// <param name="EmployeeIDs"></param>
        /// <returns></returns>
        int Delete(int[] EmployeeIDs);
    }
}
