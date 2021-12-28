using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using CoreCrud_strdProcedureEntityFramework.Models;
using SProcedure_WITHEntityFramework.Data;
using SProcedure_WITHEntityFramework.Infrastructure;
using SProcedure_WITHEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace SProcedure_WITHEntityFramework.Repository
{
    public class Student_Storedprocedure : IStudentServices
    {
        private readonly ApplicationDbContext _context;
        public Student_Storedprocedure(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Student_dj>> GetAllStudentsAsync()
        {
            return await _context.Students_dj.FromSqlRaw($"GetStudents").ToListAsync();
        }
        public async Task<List<Student_dj>> GetStudentsById(int id)
        {
            string StoredProc = "exec GetStudentById " +
                "@StudentId = " + id + "";
            return await _context.Students_dj.FromSqlRaw(StoredProc).ToListAsync();
        }
        public async Task SaveAsync(Student_dj student)
        {
            string StoredProc = "exec SaveOrUpdateStudent " +
                "@StudentId = " + student.StudentId + "," +
                "@Name = '" + student.Name + "'," +
                "@Age = " + student.Age + "";
            await _context.Students_dj.FromSqlRaw(StoredProc).ToListAsync();
        }
        public async Task updateAsync(int id)
        {
            string StoredProc = "exec GetStudentById " +
                 "@StudentId = " + id + "";
            await _context.Students_dj.FromSqlRaw(StoredProc).ToListAsync();
        }
        public async Task updateAsync(Student_dj student)
        {
            string StoredProc = "exec SaveOrUpdateStudent " +
               "@StudentId = " + student.StudentId + "," +
               "@Name = '" + student.Name + "'," +
               "@Age = " + student.Age + "";
            await _context.Students_dj.FromSqlRaw(StoredProc).ToListAsync();
        }
        public async Task DeleteAsync(int id)
        {
            
             string StoredProc = "exec DeleteStudent " +
                 "@StudentId = " + id + "";
            await _context.Students_dj.FromSqlRaw(StoredProc).ToListAsync();
        }
        public async Task<List<Student_dj>> DeleteAsync(Student_dj student)
        {
            string StoredProc = "exec DeleteStudent " +
               "@StudentId = " + student.StudentId + "";
             await _context.Students_dj.FromSqlRaw(StoredProc).ToListAsync();
            return await _context.Students_dj.FromSqlRaw($"GetStudents").ToListAsync();
        }
    }
}
