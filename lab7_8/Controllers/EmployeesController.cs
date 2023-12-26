using Microsoft.AspNetCore.Mvc;
using lab7_8.Models;
using lab7_8.Data;
using lab7_8.Validators;

namespace lab7_8.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Email,Age,PhoneNumber,Address,City,Country,IsEmployed,Salary")] EmployeeModel employeeModel)
        {
            var validator = new EmployeeModelValidator();
            var validationResult = validator.Validate(employeeModel);

            if (validationResult.IsValid)
            {
                _context.Employees.Add(employeeModel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError("", error.ErrorMessage);
            }

            return View(employeeModel);
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
    }
}
