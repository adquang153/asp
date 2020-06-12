using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin
{
    public static class SelectListHelper
    {
        public static List<SelectListItem> Countries(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (allowSelectAll)
            {
                list.Add(new SelectListItem() { Value = "", Text = "--Choose Country--" });
            }
            List<Country> data = CatalogBLL.ListOfCountries();
            foreach(var country in data)
            {
                list.Add(new SelectListItem() { Value = country.CountryName, Text = country.CountryName });
            }
            return list;
        }
        public static List<SelectListItem> Categories(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if(allowSelectAll)
            {
                list.Add(new SelectListItem() { Value = "0", Text = "--Choose Category--" });
            }
            List<Category> data = CatalogBLL.ListOfCategories(1, -1, "");
            foreach(var category in data)
            {
                list.Add(new SelectListItem() { Value = Convert.ToString(category.CategoryID), Text = category.CategoryName });
            }

            return list;
        }
        public static List<SelectListItem> Suppliers(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (allowSelectAll)
            {
                list.Add(new SelectListItem() { Value = "0", Text = "--Choose Supplier--" });
            }
            List<Supplier> data = CatalogBLL.ListOfSuppliers(1, -1, "");
            foreach (var supplier in data)
            {
                list.Add(new SelectListItem() { Value = Convert.ToString(supplier.SupplierID), Text = supplier.CompanyName });
            }

            return list;
        }
        public static List<SelectListItem> Attributes(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (allowSelectAll)
            {
                list.Add(new SelectListItem() { Value = "", Text = "--Choose Attribute--" });
            }
            List<Attributes> data = CatalogBLL.ListOfAttributes();
            foreach (var attribute in data)
            {
                list.Add(new SelectListItem() { Value = attribute.AttributeName, Text = attribute.AttributeName });
            }
            return list;
        }
    }
}