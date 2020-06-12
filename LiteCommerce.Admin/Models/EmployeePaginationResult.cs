using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin.Models
{
    public class EmployeePaginationResult : PaginationResult
    {
        /// <summary>
        /// Danh sách Employee
        /// </summary>
        public List<Employee> Data { get; set; }
    }
}