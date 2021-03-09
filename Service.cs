using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAppFITSTIC.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazorAppFITSTIC.Repository
{
    public class StudentService
    {
        private readonly ApplicationDbContext db;
        public StudentService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Student>> GetStudents()
        {
            return await db.Students
                .Include(s => s.Corsi)
                .OrderBy(s => s.Cognome)
                .ToListAsync();
        }

        public async Task UpdateStudent(Student s)
        {
            db.Entry(s).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task AddNewStudent(Student s)
        {
            db.Students.Add(s);
            await db.SaveChangesAsync();

        }

        public async Task Remove(Student s)
        {
            db.Remove(s);
            await db.SaveChangesAsync();
        }


    }
    public class CourseService
    {
        private readonly ApplicationDbContext db;
        public CourseService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Course>> GetCourses()
        {
            return await db.Courses
                .Include(c => c.Students)
                .OrderBy(c => c.Nome)
                .ToListAsync();
        }

        public async Task UpdateCourse(Course c)
        {
            db.Entry(c).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task AddNewCourse(Course c)
        {
            db.Courses.Add(c);
            await db.SaveChangesAsync();
        }

        public async Task Remove(Course c)
        {
            db.Courses.Remove(c);
            await db.SaveChangesAsync();
        }
    }
    public class TeacherService
    {
        private readonly ApplicationDbContext db;
        public TeacherService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<Teacher>> GetTeachers()
        {
            return await db.Teachers
                .Include(t => t.Corsi)
                .OrderBy(t => t.Cognome)
                .ToListAsync();
        }

        public async Task UpdateTeacher(Teacher t)
        {
            db.Entry(t).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task AddNewteacher(Teacher t)
        {
            db.Teachers.Add(t);
            await db.SaveChangesAsync();
        }
        public async Task Remove(Teacher t)
        {
            db.Teachers.Remove(t);
            await db.SaveChangesAsync();
        }
    }
}
