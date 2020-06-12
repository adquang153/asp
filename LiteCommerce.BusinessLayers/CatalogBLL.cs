using LiteCommerce.DomainModels;
using LiteCommerce.DataLayers;
using LiteCommerce.DataLayers.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.BusinessLayers
{
    /// <summary>
    /// Các chức năng xử lý nghiệp vụ liên quan đến 
    /// quản lý dữ liệu chung của hệ thống như: nhà cung cấp, khách hàng, mặt hàng,...
    /// </summary>
    public static class CatalogBLL
    {
        public static void Initialize(string connectionString)
        {
            SupplierDB = new DataLayers.SQLServer.SupplierDAL(connectionString);
            CustomerDB = new DataLayers.SQLServer.CustomerDAL(connectionString);
            ShipperDB = new DataLayers.SQLServer.ShipperDAL(connectionString);
            CategoryDB = new DataLayers.SQLServer.CategoryDAL(connectionString);
            EmployeeDB = new DataLayers.SQLServer.EmployeeDAL(connectionString);
            ProductDB = new DataLayers.SQLServer.ProductDAL(connectionString);
            CountryDB = new DataLayers.SQLServer.CountryDAL(connectionString);
            AttributeDB = new DataLayers.SQLServer.AttributeDAL(connectionString);
            ProductAttributeDB = new DataLayers.SQLServer.ProductAttributeDAL(connectionString);
        }

        #region Khai báo các thuộc tính giao tiếp với DAL
        private static ISupplierDAL SupplierDB { get; set; }
        private static ICustomerDAL CustomerDB { get; set; }
        private static IShipperDAL ShipperDB { get; set; }
        private static ICategoryDAL CategoryDB { get; set; }
        private static IEmployeeDAL EmployeeDB { get; set; }
        private static IProductDAL ProductDB { get; set; }
        private static ICountryDAL CountryDB { get; set; }
        private static IAttributeDAL AttributeDB { get; set; }
        private static IProductAttributeDAL ProductAttributeDB { get; set; }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = SupplierDB.Count(searchValue);
            return SupplierDB.List(page, pageSize, searchValue);

        }
        public static List<Supplier> ListOfSuppliers(int page, int pageSize, string searchValue)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 100;
            return SupplierDB.List(page, pageSize, searchValue);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int supplierID)
        {
            return SupplierDB.Get(supplierID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSupplier(Supplier data)
        {
            return SupplierDB.Add(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier data)
        {
            return SupplierDB.Update(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierIDs"></param>
        /// <returns></returns>
        public static int DeleteSuppliers(int[] supplierIDs)
        {
            return SupplierDB.Delete(supplierIDs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(int page, int pageSize, string searchValue, string country, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = CustomerDB.Count(searchValue);
            return CustomerDB.List(page, pageSize, searchValue, country);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static Customer GetCustomer(string customerID)
        {
            return CustomerDB.Get(customerID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string AddCustomer(Customer data)
        {
            return CustomerDB.Add(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCustomer(Customer data)
        {
            return CustomerDB.Update(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIDs"></param>
        /// <returns></returns>
        public static int DeleteCustomer(string[] customerIDs)
        {
            return CustomerDB.Delete(customerIDs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = ShipperDB.Count(searchValue);
            return ShipperDB.List(page, pageSize, searchValue);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static Shipper GetShipper(int shipperID)
        {
            return ShipperDB.Get(shipperID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddShipper(Shipper data)
        {
            return ShipperDB.Add(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateShipper(Shipper data)
        {
            return ShipperDB.Update(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipperIDs"></param>
        /// <returns></returns>
        public static int DeleteShippers(int[] shipperIDs)
        {
            return ShipperDB.Delete(shipperIDs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Category> ListOfCategories(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = CategoryDB.Count(searchValue);
            return CategoryDB.List(page, pageSize, searchValue);
        }
        public static List<Category> ListOfCategories(int page, int pageSize, string searchValue)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 100;
            return CategoryDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static Category GetCategory(int categoryID)
        {
            return CategoryDB.Get(categoryID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCategory(Category data)
        {
            return CategoryDB.Add(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCategory(Category data)
        {
            return CategoryDB.Update(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryIDs"></param>
        /// <returns></returns>
        public static int DeleteCategories(int[] categoryIDs)
        {
            return CategoryDB.Delete(categoryIDs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(int page, int pageSize, string searchValue, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = EmployeeDB.Count(searchValue);
            return EmployeeDB.List(page, pageSize, searchValue);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static Employee GetEmployee(int employeeID)
        {
            return EmployeeDB.Get(employeeID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddEmployee(Employee data)
        {
            return EmployeeDB.Add(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateEmployee(Employee data)
        {
            return EmployeeDB.Update(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeIDs"></param>
        /// <returns></returns>
        public static int DeleteEmployees(int[] employeeIDs)
        {
            return EmployeeDB.Delete(employeeIDs);
        }
        public static List<Product> ListOfProducts(int page, int pageSize, string searchValue, int category, int supplier, out int rowCount)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 0)
                pageSize = 20;
            rowCount = ProductDB.Count(searchValue, category, supplier);
            return ProductDB.List(page, pageSize, searchValue, category, supplier);
        }
        public static Product GetProduct(int productID)
        {
            return ProductDB.Get(productID);
        }
        public static int AddProduct(Product data)
        {
            return ProductDB.Add(data);
        }
        public static bool UpdateProduct(Product data)
        {
            return ProductDB.Update(data);
        }
        public static int DeleteProducts(int[] productIDs)
        {
            return ProductDB.Delete(productIDs);
        }
        public static List<Country> ListOfCountries()
        {
            return CountryDB.List();
        }
        public static List<Attributes> ListOfAttributes()
        {
            return AttributeDB.List();
        }
        public static List<ProductAttribute> ListOfProductAttribute(int productID)
        {
            return ProductAttributeDB.List(productID);
        }
        public static int AddProductAttribute(ProductAttribute data)
        {
            return ProductAttributeDB.Add(data);
        }
        public static bool UpdateProductAttribute(ProductAttribute data)
        {
            return ProductAttributeDB.Update(data);
        }
        public static int DeleteProductAttributes(int[] attributeIDs)
        {
            return ProductAttributeDB.Delete(attributeIDs);
        }
        public static ProductAttribute GetProductAttribute(int attributeID)
        {
            return ProductAttributeDB.Get(attributeID);
        }
    }
}
