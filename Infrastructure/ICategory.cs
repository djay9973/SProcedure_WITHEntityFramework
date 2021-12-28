using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SProcedure_WITHEntityFramework.Models;
using SProcedure_WITHEntityFramework.Data;

namespace SProcedure_WITHEntityFramework.Infrastructure
{
   public interface ICategory
    {
        Task<List<Category>> GetAllAsync();
        Task saveAsync();
        Task insertAsync(Category category);
        Task DeleteAsync(int id);
        Task updateAsync(Category category);
        Task<Category> GetByIDAsync(int Id);
    }
}
