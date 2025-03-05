using Day1.Data;
using Day1.Models;
using Day1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    public class StudentController : Controller
    {   
        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Students = _context.Students.ToList();
            return View(Students);   
        }
        public IActionResult Details(int id=3) {
            var curStudent = _context.Students.Find(id);
            var courseRelated = _context.Stud_Courses.Where(x => x.StudentId == id).ToList();

            var AllCourseNames = (from c in _context.Courses
                                  join sc in _context.Stud_Courses on c.Id equals sc.CourseId
                                  where sc.StudentId == id
                                  select new CourseManyVM
                                  {
                                      CourseName = c.Name,
                                      MinDegree = c.minDegree,
                                      Degree = sc.Degree
                                  }).ToList();

            StudentAndCourseVM studentVM = new StudentAndCourseVM();
            studentVM.Id = curStudent.Id;
            studentVM.Name = curStudent.Name;
            studentVM.Address = curStudent.Address;
            studentVM.Age = curStudent.Age;
            studentVM.Courses = AllCourseNames;

            studentVM.curCookieName = HttpContext.Session.GetString("Name"); // session 
            return View(studentVM);
        }

       
    }   
}
