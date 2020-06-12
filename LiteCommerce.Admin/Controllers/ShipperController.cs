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
    public class ShipperController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 3;
            int rowCount = 0;
            List<Shipper> listOfShipper = CatalogBLL.ListOfShippers(page, pageSize, searchValue, out rowCount);
            var model = new Models.ShipperPaginationResult()
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                SearchValue = searchValue,
                Data = listOfShipper
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
                    ViewBag.Title = "Create new Shipper";
                    Shipper newShipper = new Shipper()
                    {
                        ShipperID = 0
                    };
                    return View(newShipper);
                }
                else
                {
                    ViewBag.Title = "Edit Shipper";
                    Shipper editShipper = CatalogBLL.GetShipper(Convert.ToInt32(id));
                    if (editShipper == null)
                        return RedirectToAction("Index");
                    return View(editShipper);
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
        public ActionResult Input(Shipper model)
        {
            try
            {
                //TODO: Kiểm tra tính hợp lệ của dữ liệu
                if (string.IsNullOrEmpty(model.CompanyName))
                    ModelState.AddModelError("CompanyName", "CompanyName expected!");
                if (string.IsNullOrEmpty(model.Phone))
                    model.Phone = "";

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                //TODO: Lưu dữ liệu vào DB
                if (model.ShipperID == 0)
                {
                    CatalogBLL.AddShipper(model);
                }
                else
                {
                    CatalogBLL.UpdateShipper(model);
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
        public ActionResult Delete(int[] shipperIDs = null)
        {
            if (shipperIDs != null)
                CatalogBLL.DeleteShippers(shipperIDs);
            return RedirectToAction("Index");
        }
    }
}