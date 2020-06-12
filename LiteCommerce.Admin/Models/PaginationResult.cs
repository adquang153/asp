using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin.Models
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PaginationResult
    {
        /// <summary>
        /// Trang
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Kích thước trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Số dòng
        /// </summary>
        public int RowCount { get; set; }
        public string SearchValue { get; set; }
        public int PageCount
        {
            get
            {
                int p = RowCount / PageSize;
                if (RowCount % PageSize > 0)
                    p += 1;
                return p;
            }
        }
    }
}