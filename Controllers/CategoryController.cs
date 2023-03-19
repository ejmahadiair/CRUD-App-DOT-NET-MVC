using Microsoft.AspNetCore.Mvc;
using ReadBookWebApp.Data;
using ReadBookWebApp.Models;

namespace ReadBookWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name== obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name can not exactly match the DisplayOrder");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                TempData["success"] = "Category Created Successfully!";
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
           
        }
        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var catagoryFormDb = _db.Categories.Find(id);

            if(catagoryFormDb == null)
            {
                return NotFound();
            }

            return View(catagoryFormDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name can not exactly match the DisplayOrder");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
				TempData["success"] = "Category Updated Successfully!";
				_db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
		//Get


		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var catagoryFormDb = _db.Categories.Find(id);

			if (catagoryFormDb == null)
			{
				return NotFound();
			}

			return View(catagoryFormDb);
		}

		//Delete
		[HttpPost]
        [ValidateAntiForgeryToken]


        public IActionResult DeletePost(int? id)
        {
                var obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
			TempData["success"] = "Category Deleted Successfully!";
			_db.SaveChanges();
                return RedirectToAction("Index");

        }
    }
}
