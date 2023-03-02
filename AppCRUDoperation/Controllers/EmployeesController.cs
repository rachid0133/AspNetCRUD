using AppCRUDoperation.Data;
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
