using Day1.Data;
using Day1.Models;
using Day1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day1.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _context;
        public InstructorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Instructors = _context.Instructors.ToList();
            return View(Instructors);
        }
        public IActionResult Details(int id=2)
        {
            var InstructorAndRelated = _context.Instructors.Include(x=>x.Courses)
                .FirstOrDefault(x=>x.Id == id);
            return View(InstructorAndRelated);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var CurInstructor = _context.Instructors.Find(id);
            var allDepartments = _context.Departments.ToList();
            InstructorEditVM InstructorVM = new InstructorEditVM();
            InstructorVM.Id = CurInstructor.Id;
            InstructorVM.Age = CurInstructor.Age;
            InstructorVM.Img = CurInstructor.Img;
            InstructorVM.FName = CurInstructor.FName;
            InstructorVM.LName = CurInstructor.LName;
            InstructorVM.DeptId = CurInstructor.DeptId;
            InstructorVM.Salary = CurInstructor.Salary;

            InstructorVM.departments = allDepartments;
            return View(InstructorVM);
        }
        [HttpPost]
        public IActionResult Edit(InstructorEditVM InstVM)
        {
            var instructor = _context.Instructors.Find(InstVM.Id);
            if (InstVM.FName != null && InstVM.LName != null && InstVM.Img != null)
            {

                instructor.FName = InstVM.FName;
                instructor.LName = InstVM.LName;
                instructor.Salary = InstVM.Salary;
                instructor.Img = InstVM.Img;
                instructor.Age = InstVM.Age;
                instructor.DeptId = InstVM.DeptId;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            InstVM.departments = _context.Departments.ToList();
            return View(InstVM);
        }

        [HttpGet]
        public IActionResult Add()
        {
            InstructorAddVM newVM = new InstructorAddVM();
            newVM.departments = _context.Departments.ToList();
            return View(newVM);
        }
        [HttpPost]
        public IActionResult Add(InstructorAddVM addVM)
        {
            if(addVM.FName != null && addVM.LName!=null)
            {
                Instructor newInst = new Instructor();

                newInst.FName = addVM.FName;
                newInst.LName = addVM.LName;
                newInst.Age = addVM.Age;
                newInst.Img = addVM.Img;
                newInst.DeptId=addVM.DeptId;
                newInst.Salary = addVM.Salary;

                _context.Add(newInst);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            addVM.departments = _context.Departments.ToList();
            return View(addVM);
        }

        public IActionResult Delete(int id)
        {
            var curInstructor = _context.Instructors.Where(x=>x.Id== id).FirstOrDefault();
            if (curInstructor != null)
            {
                _context.Instructors.Remove(curInstructor);
                _context.SaveChanges();
            }
            var Instructors = _context.Instructors.ToList();

            return View("Index",Instructors);
        }
    }
}
