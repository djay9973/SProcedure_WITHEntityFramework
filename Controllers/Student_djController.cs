using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SProcedure_WITHEntityFramework.Data;
using SProcedure_WITHEntityFramework.Infrastructure;
using SProcedure_WITHEntityFramework.Models;

namespace SProcedure_WITHEntityFramework.Controllers
{
    public class Student_djController : Controller
    {
        private readonly IStudentServices _IStudentServices;
        public Student_djController(IStudentServices IStudentServices)
        {
            _IStudentServices = IStudentServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _IStudentServices.GetAllStudentsAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _IStudentServices.GetStudentsById(id);
            return View(item.FirstOrDefault());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student_dj student)
        {
            await _IStudentServices.DeleteAsync(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student_dj student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _IStudentServices.SaveAsync(student);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var item = await _IStudentServices.GetStudentsById(id);
            return View(item.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student_dj student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _IStudentServices.SaveAsync(student);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _IStudentServices.GetStudentsById(id);
            return View(item.FirstOrDefault());
        }
    }
}
