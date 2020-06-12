using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Roles = WebUserRoles.ACCOUNT)]
    public class EmployeeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Employee> listOfEmployee = CatalogBLL.ListOfEmployees(page, pageSize, searchValue, out rowCount);
            var model = new Models.EmployeePaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                SearchValue = searchValue,
                Data = listOfEmployee
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
                    ViewBag.Title = "Create new Employee";
                    Employee newEmployee = new Employee()
                    {
                        EmployeeID = 0
                    };
                    return View(newEmployee);
                }
                else
                {
                    ViewBag.Title = "Edit Employee";
                    Employee editEmployee = CatalogBLL.GetEmployee(Convert.ToInt32(id));
                    if (editEmployee == null)
                        return RedirectToAction("Index");
                    return View(editEmployee);
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
        public ActionResult Input(Employee model, HttpPostedFileBase uploadFile)
        {
            try
            {
                //TODO: Kiểm tra tính hợp lệ của dữ liệu
                if (string.IsNullOrEmpty(model.LastName))
                    ModelState.AddModelError("LastName", "LastName expected!");
                if (string.IsNullOrEmpty(model.FirstName))
                    ModelState.AddModelError("FirstName", "FirstName expected!");
                if (string.IsNullOrEmpty(model.Title))
                    ModelState.AddModelError("Title", "Title expected!");
                if (string.IsNullOrEmpty(model.Email))
                    ModelState.AddModelError("Email", "Email expected!");
                if (string.IsNullOrEmpty(model.Address))
                    model.Address = "";
                if (string.IsNullOrEmpty(model.Address))
                    model.Address = "";
                if (string.IsNullOrEmpty(model.Country))
                    model.Country = "";
                if (string.IsNullOrEmpty(model.City))
                    model.City = "";
                if (string.IsNullOrEmpty(model.HomePhone))
                    model.HomePhone = "";
                if (string.IsNullOrEmpty(model.Notes))
                    model.Notes = "";
                if (string.IsNullOrEmpty(model.PhotoPath))
                    model.PhotoPath = "";
                if (string.IsNullOrEmpty(model.Password))
                    model.Password = "";

                //Upload ảnh
                if (uploadFile != null)
                {
                    string folder = Server.MapPath("~/Images/Uploads");
                    //Lấy phần mở rộng của file
                    string extensionName = System.IO.Path.GetExtension(uploadFile.FileName);
                    if (!extensionName.Equals(".jpg") && !extensionName.Equals(".JPG") && !extensionName.Equals(".png") && !extensionName.Equals(".PNG"))
                        ModelState.AddModelError("ExtensionName", "File type expected!");
                    else
                    {
                        // Tạo tên file ngẫu nhiên
                        string fileName = $"{DateTime.Now.Ticks}{Path.GetExtension(uploadFile.FileName)}";
                        string filePath = Path.Combine(folder, fileName);
                        uploadFile.SaveAs(filePath);

                        model.PhotoPath = fileName;
                    }
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                //Lưu dữ liệu vào DB
                if (model.EmployeeID == 0)
                {
                    CatalogBLL.AddEmployee(model);
                }
                else
                {
                    CatalogBLL.UpdateEmployee(model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ":" + ex.StackTrace);
                return View(model);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierIDs"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int[] employeeIDs = null)
        {
            if (employeeIDs != null)
                CatalogBLL.DeleteEmployees(employeeIDs);
            return RedirectToAction("Index");
        }
    }
}