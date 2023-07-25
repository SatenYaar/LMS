using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers.Employee
{
  //  [Authorize]
    public class LeavesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUpdate(int? id)
        {
            ViewBag.UserName = User.Identity.Name;


            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (product.Id == 0)
        //        {

        //            _productRepository.AddProduct(product);
        //        }
        //        else
        //        {
        //            _productRepository.UpdateProduct(product);
        //        }

        //        return RedirectToAction("Index", "Home"); 
        //    }

        //    return View(product);
        //}
    }
}
