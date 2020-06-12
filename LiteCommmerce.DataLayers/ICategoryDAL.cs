using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface ICategoryDAL
    {
        /// <summary>
        /// Hiển thị DS Category, phân trang và có thể tìm kiếm
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Category> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// Đếm số lượng kết quả tìm kiếm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// Lấy dữ liệu của 1 Category dựa vào ID
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        Category Get(int CategoryID);
        /// <summary>
        /// Bổ sung 1 Category, hàm trả về ID của Category đã bổ sung
        /// Nếu lỗi trả về giá trị nhỏ hơn hoặc bằng 0
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Category data);
        /// <summary>
        /// Cập nhật dữ liệu 1 Category
        /// Hàm trả về true nếu thành công và false nếu thất bại
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Category data);
        /// <summary>
        /// Xóa những Category được chọn
        /// Hàm trả về số Category đã xóa được
        /// </summary>
        /// <param name="CategoryIDs"></param>
        /// <returns></returns>
        int Delete(int[] CategoryIDs);
    }
}
