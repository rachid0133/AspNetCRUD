﻿using AppCRUDoperation.Data;
using AppCRUDoperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AppCRUDoperation.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            var result = _context.Employees.Include(b=>b.Department).OrderBy(b=>b.EmployeeName).ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            ViewBag.Departements = _context.Departments.OrderBy(x=>x.DepartementName).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee model)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() >0) {
                //upload image
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", "images", imageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                model.ImageUser = imageName;
            }
            else if(model.ImageUser == null && model.EmployeeId==null) {
                //Image not uploaded
                model.ImageUser= "DefaultImage.jpg";
            }
            else
            {
                model.ImageUser = model.ImageUser;
            }
            if (ModelState.IsValid)
            {
                _context.Employees.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departements = _context.Departments.OrderBy(x => x.DepartementName).ToList();

            return View();
        }
    }
}
