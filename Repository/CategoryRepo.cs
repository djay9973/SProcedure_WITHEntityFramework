using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using DI_Crud.Infrastructure;
using SProcedure_WITHEntityFramework.Models;
using SProcedure_WITHEntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using SProcedure_WITHEntityFramework.Infrastructure;

namespace SProcedure_WITHEntityFramework.Repository
{
    public class CategoryRepo : ICategory
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            Category ss = await GetByIDAsync(id);
            _context.Remove(ss);
        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories_dj.ToListAsync();
        }
        public async Task<Category> GetByIDAsync(int Id)
        {
            return await _context.Categories_dj.FindAsync(Id);
        }
        public async Task insertAsync(Category category)
        {
            await _context.AddAsync(category);
        }
        public async Task saveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task updateAsync(Category category)
        {
            _context.Categories_dj.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
