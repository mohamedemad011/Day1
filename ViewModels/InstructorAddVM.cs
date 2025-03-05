using Day1.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day1.ViewModels
{
    public class InstructorAddVM
    {
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public int Salary { get; set; }
        public string Img { get; set; } = string.Empty;
        public int Age { get; set; }
        public int DeptId { get; set; }
        public List<Department> departments { get; set; } = new List<Department>();
    }
}
