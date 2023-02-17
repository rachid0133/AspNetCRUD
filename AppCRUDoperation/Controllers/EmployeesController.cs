using AppCRUDoperation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

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
            var result = _context.Employees.ToList();
            return View(result);
        }
    }
}
