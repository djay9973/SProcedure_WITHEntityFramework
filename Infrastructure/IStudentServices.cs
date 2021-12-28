using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SProcedure_WITHEntityFramework.Models;

namespace SProcedure_WITHEntityFramework.Infrastructure
{
   public interface IStudentServices
    {
        Task<List<Student_dj>> GetAllStudentsAsync();
        Task SaveAsync(Student_dj student);
        Task DeleteAsync(int id);
        Task<List<Student_dj>> DeleteAsync(Student_dj student);
        //Task saveAsync();
        Task updateAsync(int id);
        Task updateAsync(Student_dj student);
        Task<List<Student_dj>> GetStudentsById(int id);
    }
}
