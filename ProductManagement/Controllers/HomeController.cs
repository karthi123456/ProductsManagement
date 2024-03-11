using ProductManagement.Models;
using ProductManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly CategoryService _categoryService;
        public HomeController()
        {
            this._categoryService = new CategoryService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategories()
        {
            List<Category> cateGories = _categoryService.GetCategories().ToList();

            return Json(new { cateGories }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Products(int categoryId)
        {
            List<ProductsCategory> productsCategory = _categoryService.GetProductCategoriesById(categoryId);

            return View(productsCategory);
        }

        public ActionResult CartItems()
        {
            return View();
        }
    }
}