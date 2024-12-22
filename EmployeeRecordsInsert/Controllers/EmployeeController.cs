using EmployeeRecordsInsert.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRecordsInsert.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home/Create
        public IActionResult Details()
        {
            List<EmployeeData> objcategories = _context.EmployeeRecord.ToList();
            if (objcategories == null)
            {
                return NotFound();
            }
            return View(objcategories);
        }
        // POST: Home/Save
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public EmployeeData Save(EmployeeData details)
        {
            EmployeeData newdata = new EmployeeData();
            newdata.EmployeeId = details.EmployeeId;
            newdata.EmployeeName = details.EmployeeName;
            newdata.BasicSalary = details.BasicSalary;
            newdata.DateOfBirth = details.DateOfBirth;
            newdata.Department = details.Department;
            newdata.Designation = details.Designation;
            newdata.Gender = details.Gender;

            if (ModelState.IsValid)
            {
                _context.EmployeeRecord.Add(newdata); // Add to context
                _context.SaveChanges();          // Save changes to database
                /*return RedirectToAction("Index");*/ // Redirect to a confirmation page or list
            }

            return newdata; // Return to the form if validation fails
        }

        // GET: Employee/Index
        public ActionResult Index()
        {
            var employees = _context.EmployeeRecord.ToList();
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees); // Display the list of employees
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
