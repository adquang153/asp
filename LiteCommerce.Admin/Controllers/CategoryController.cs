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
    public class CategoryController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Category> listOfCategory = CatalogBLL.ListOfCategories(page, pageSize, searchValue, out rowCount);
            var model = new Models.CategoryPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                SearchValue = searchValue,
                Data = listOfCategory
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
                    ViewBag.Title = "Create new Category";
                    Category newCategory = new Category()
                    {
                        CategoryID = 0
                    };
                    return View(newCategory);
                }
                else
                {
                    ViewBag.Title = "Edit Category";
                    Category editCategory = CatalogBLL.GetCategory(Convert.ToInt32(id));
                    if (editCategory == null)
                        return RedirectToAction("Index");
                    return View(editCategory);
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
        public ActionResult Input(Category model)
        {
            try
            {
                //TODO: Kiểm tra tính hợp lệ của dữ liệu
                if (string.IsNullOrEmpty(model.CategoryName))
                    ModelState.AddModelError("CategoryName", "CategoryName expected!");
                if (string.IsNullOrEmpty(model.Description))
                    model.Description = "";

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                //TODO: Lưu dữ liệu vào DB
                if (model.CategoryID == 0)
                {
                    CatalogBLL.AddCategory(model);
                }
                else
                {
                    CatalogBLL.UpdateCategory(model);
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
        /// <param name="categoryIDs"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int[] categoryIDs = null)
        {
            if (categoryIDs != null)
                CatalogBLL.DeleteCategories(categoryIDs);
            return RedirectToAction("Index");
        }
    }
}