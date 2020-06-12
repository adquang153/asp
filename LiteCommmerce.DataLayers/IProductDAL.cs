using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IProductDAL
    {
        /// <summary>
        /// Hiển thị DS Product, phân trang và có thể tìm kiếm
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="category"></param>
        /// <param name="supplier"></param>
        /// <returns></returns>
        List<Product> List(int page, int pageSize, string searchValue, int category, int supplier);
        /// <summary>
        /// Đếm số lượng kết quả tìm kiếm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue, int category, int supplier);
        /// <summary>
        /// Lấy dữ liệu của 1 Product dựa vào ID
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        Product Get(int ProductID);
        /// <summary>
        /// Bổ sung 1 Product, hàm trả về ID của Product đã bổ sung
        /// Nếu lỗi trả về giá trị nhỏ hơn hoặc bằng 0
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Product data);
        /// <summary>
        /// Cập nhật dữ liệu 1 Product
        /// Hàm trả về true nếu thành công và false nếu thất bại
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Product data);
        /// <summary>
        /// Xóa những Product được chọn
        /// Hàm trả về số Product đã xóa được
        /// </summary>
        /// <param name="ProductIDs"></param>
        /// <returns></returns>
        int Delete(int[] ProductIDs);
    }
}
