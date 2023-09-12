using ManagementPortal.Models;

using Microsoft.AspNetCore.Mvc;

using ManagementPortal.Data;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;

namespace ManagementPortal.Controllers


{
    public class EmployeeController : Controller
    {
        private EmployeeContext context { get; set; }
        public EmployeeController(EmployeeContext ctx)
        {
            context = ctx;
        }

        [Authorize]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            ViewBag.Departments = context.Departments.OrderBy(d => d.DepartmentName).ToList();
            return View("Edit", new Employee());
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            ViewBag.Departments = context.Departments.OrderBy(d => d.DepartmentName).ToList();
            var employee = context.Employees.Find(id);
            return View(employee);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                if (employee.Id == 0)
                {
                    context.Employees.Add(employee);
                }
                else
                {
                    context.Employees.Update(employee);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ViewBag.Departments = context.Departments.OrderBy(d => d.DepartmentName).ToList();

                ViewBag.Action = (employee.Id == 0) ? "Add" : "Edit";
                return View(employee);
            }

        }
        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {

            ViewBag.Action = "Delete";
            var employee = context.Employees.Find(id);
            return View(employee);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {

            ViewBag.Action = "Delete";
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index", "Employee");

        }
        public IActionResult Index(string searchString)
        {
            var employees = from e in context.Employees.Include(e => e.Department) select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Name.Contains(searchString));
            }
            return View(employees.ToList());
        }
        [HttpGet]
        public IActionResult Salary()
        {
            ViewBag.Salary = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Salary(Employee model)
        {
            ViewBag.Salary = model.CalculatePay();
            return View(model);
        }
    }
}
