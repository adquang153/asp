using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Roles = WebUserRoles.DATA)]
    public class CustomerController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1, string searchValue = "", string Country = "")
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Customer> listOfCustomers = CatalogBLL.ListOfCustomers(page, pageSize, searchValue, Country, out rowCount);
            var model = new Models.CustomerPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                Country = Country,
                SearchValue = searchValue,
                Data = listOfCustomers
            };
            return View(model);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Input(string id = "")
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    ViewBag.Title = "Create new Customer";
                    ViewBag.Method = "Add";
                    Customer newCustomer = new Customer()
                    {
                        CustomerID = ""
                    };
                    return View(newCustomer);
                }
                else
                {
                    ViewBag.Title = "Edit Customer";
                    ViewBag.Method = "Edit";
                    Customer editCustomer = CatalogBLL.GetCustomer(Convert.ToString(id));
                    if (editCustomer == null)
                        return RedirectToAction("Index");
                    return View(editCustomer);
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message + ":" + ex.StackTrace);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Input(Customer model, string method)
        {
            try
            {
                //TODO: Kiểm tra tính hợp lệ của dữ liệu
                if (string.IsNullOrEmpty(model.CustomerID))
                    ModelState.AddModelError("CustomerID", "CustomerID expected!");
                if (string.IsNullOrEmpty(model.CompanyName))
                    ModelState.AddModelError("CompanyName", "CompanyName expected!");
                if (string.IsNullOrEmpty(model.ContactName))
                    ModelState.AddModelError("ContactName", "ContactName expected!");
                if (string.IsNullOrEmpty(model.ContactTitle))
                    ModelState.AddModelError("ContactTitle", "ContactTitle expected!");
                if (string.IsNullOrEmpty(model.Address))
                    model.Address = "";
                if (string.IsNullOrEmpty(model.Country))
                    model.Country = "";
                if (string.IsNullOrEmpty(model.City))
                    model.City = "";
                if (string.IsNullOrEmpty(model.Phone))
                    model.Phone = "";
                if (string.IsNullOrEmpty(model.Fax))
                    model.Fax = "";

                if (!ModelState.IsValid)
                {
                    ViewBag.Title = (method=="Add")? "Create new Customer": "Edit Customer";
                    return View(model);
                }

                //TODO: Lưu dữ liệu vào DB
                if (method == "Add")
                {
                    CatalogBLL.AddCustomer(model);
                }
                else if(method == "Edit")
                {
                    CatalogBLL.UpdateCustomer(model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ":" + ex.StackTrace);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Delete(string[] customerIDs = null)
        {
            if (customerIDs != null)
                CatalogBLL.DeleteCustomer(customerIDs);
            return RedirectToAction("Index");
        }
    }
}