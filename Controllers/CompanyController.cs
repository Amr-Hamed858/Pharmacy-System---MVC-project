using Day_6.Contexts;
using Day_6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day_6.Controllers
{
	public class CompanyController : Controller
	{
		ProductContext ProductContext;

        public CompanyController(ProductContext _productContext)
        {
            ProductContext = _productContext;
        }

        public IActionResult Index()
		{
			return View(ProductContext.Companies.ToList());
		}




		[HttpGet]
		public IActionResult Create() 
		{
			return View();
		}

        [HttpPost]
        public IActionResult Create(Company C)
        {
            if (ModelState.IsValid) 
            {
			ProductContext.Companies.Add(C);
			ProductContext.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(C);
        }







        [HttpGet]
        public IActionResult Edit(int id)
        {
            var company = ProductContext.Companies.Find(id);
            if (company == null) 
            {
                return RedirectToAction("Index");
            }
            return View(company);
        }

        [HttpPost]
        public IActionResult Edit(Company C)
        {
            if (ModelState.IsValid) 
            {
                ProductContext.Update(C);
                ProductContext.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(C);
        }




        [HttpGet]
        public IActionResult Delete(int id)
        {
            var company = ProductContext.Companies.Find(id);
            if (company == null)
            {
                return RedirectToAction("Index");
            }
            return View(company);
        }


        [HttpPost]
        public IActionResult Delete(Company c, string choice)
        {      
            var company = ProductContext.Companies.FirstOrDefault(cc => cc.ID == c.ID);
            if (company != null)
            {
                if (choice == "y") 
                {
                    ProductContext.Companies.Remove(company);
                    ProductContext.SaveChanges(); 
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
