using Day_6.Contexts;
using Day_6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Day_6.Controllers
{
	public class DrugController : Controller
	{
		ProductContext ProductContext ;

        public DrugController(ProductContext _productContext)
        {
            ProductContext  = _productContext;
        }


        public IActionResult Index()
		{
			return View(ProductContext.Drugs.Include(d=> d.Company));
		}





		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.comps = new SelectList(ProductContext.Companies, "ID","Name");
			return View("Create");
		}

		[HttpPost]
		public IActionResult Create(Drug d)
		{
			ModelState.Remove("Company");
			if (d != null && ModelState.IsValid)
            {
                ProductContext.Drugs.Add(d);
                ProductContext.SaveChanges();
                return RedirectToAction("Index",d);
            }
            ViewBag.comps = new SelectList(ProductContext.Companies, "ID", "Name");
			return  View();
		}





		[HttpGet]
		public IActionResult Edit(int id) 
		{
            ViewBag.comps = new SelectList(ProductContext.Companies, "ID", "Name");
            var drug = ProductContext.Drugs.Find(id);
			if (drug == null) 
			{
				return RedirectToAction("Index");
			}
			ViewBag.drugs = new SelectList(ProductContext.Drugs, "ID","Name");
			return View("Edit",drug);
		}

		[HttpPost]
		public IActionResult Edit(Drug d) 
		{
			if (ModelState.IsValid) 
			{
				ProductContext.Update(d);
				ProductContext.SaveChanges();
				return RedirectToAction("Index");
			}
            ViewBag.comps = new SelectList(ProductContext.Companies, "ID", "Name");
			return RedirectToAction("Index"); ;
        }








        [HttpGet]
        public IActionResult Delete(int id)
        {
            var drug = ProductContext.Drugs.Find(id);
            if (drug == null)
            {
                return RedirectToAction("Index");
            }
            return View("Delete", drug);
        }


        [HttpPost]
        public IActionResult Delete(Drug d)
        {
            var drug = ProductContext.Drugs.Find(d.ID);
            if (drug == null)
            {
                return RedirectToAction("Index");
            }
            ProductContext.Drugs.Remove(drug);
            ProductContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
