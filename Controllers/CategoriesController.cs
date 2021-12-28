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
    public class CategoriesController : Controller
    {
        private readonly ICategory _ICategory;

        public CategoriesController(ICategory ICategory)
        {
            _ICategory = ICategory;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _ICategory.GetAllAsync();
            return View(items);

        }
        public async Task<IActionResult> Details(int id)
        {
            var item = await _ICategory.GetByIDAsync(id);
            return View(item);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _ICategory.insertAsync(category);
                    await _ICategory.saveAsync();
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
            Category cat = await _ICategory.GetByIDAsync(id);
            return View(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            try
            {
                await _ICategory.updateAsync(category);
                await _ICategory.saveAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _ICategory.DeleteAsync(id);
            await _ICategory.saveAsync();
            return RedirectToAction("Index");
        }
    }
}
