using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employee_Mannagement.Data;
using Employee_Mannagement.Models;
using System.Net;

namespace Employee_Mannagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsValid()
        {
            return HttpContext.Session.GetString("AdminUsernameSession") == null || HttpContext.Session.GetString("AdminPasswordSession") == null;
        }

        // GET: Employee
        public async Task<IActionResult> Index(string searchby, string search)
        {
            if (IsValid() == true)
            {
                TempData["msg"] = "NEED TO LOGIN FIRST !!!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if(searchby == "firstname")
                {
                    var data = _context.Employees_Management.Where(model => model.FirstName.StartsWith(search)).ToList();
                    return View(data);
                }
                else if(searchby == "lastname")
                {
                    var data = _context.Employees_Management.Where(model => model.LastName == search).ToList();
                    return View(data);
                }
                else
                    return View(await _context.Employees_Management.ToListAsync());
            }       
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (IsValid() == true)
            {
                TempData["msg"] = "NEED TO LOGIN FIRST !!!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (id == null || _context.Employees_Management == null)
                {
                    return NotFound();
                }

                var employeeModel = await _context.Employees_Management
                    .FirstOrDefaultAsync(m => m.EmpId == id);
                if (employeeModel == null)
                {
                    return NotFound();
                }

                return View(employeeModel);
            } 
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            if (IsValid() == true)
            {
                TempData["msg"] = "NEED TO LOGIN FIRST !!!";
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,FirstName,LastName,Email,Designation,Education,Project,Address,City,Country,Phone")] EmployeeModel employeeModel)
        {
            if (IsValid() == true)
            {
                TempData["msg"] = "NEED TO LOGIN FIRST !!!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Add(employeeModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(employeeModel);
            }  
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (IsValid() == true)
            {
                TempData["msg"] = "NEED TO LOGIN FIRST !!!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (id == null || _context.Employees_Management == null)
                {
                    return NotFound();
                }

                var employeeModel = await _context.Employees_Management.FindAsync(id);
                if (employeeModel == null)
                {
                    return NotFound();
                }
                return View(employeeModel);
            }  
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,FirstName,LastName,Email,Designation,Education,Project,Address,City,Country,Phone")] EmployeeModel employeeModel)
        {
            if (IsValid() == true)
            {
                TempData["msg"] = "NEED TO LOGIN FIRST !!!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (id != employeeModel.EmpId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(employeeModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EmployeeModelExists(employeeModel.EmpId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(employeeModel);
            }    
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (IsValid() == true)
            {
                TempData["msg"] = "NEED TO LOGIN FIRST !!!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (id == null || _context.Employees_Management == null)
                {
                    return NotFound();
                }

                var employeeModel = await _context.Employees_Management
                    .FirstOrDefaultAsync(m => m.EmpId == id);
                if (employeeModel == null)
                {
                    return NotFound();
                }

                return View(employeeModel);
            }     
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (IsValid() == true)
            {
                TempData["msg"] = "NEED TO LOGIN FIRST !!!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (_context.Employees_Management == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Employees_Management'  is null.");
                }
                var employeeModel = await _context.Employees_Management.FindAsync(id);
                if (employeeModel != null)
                {
                    _context.Employees_Management.Remove(employeeModel);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }  
        }

        private bool EmployeeModelExists(int id)
        {
          return _context.Employees_Management.Any(e => e.EmpId == id);
        }
        

    }
}
