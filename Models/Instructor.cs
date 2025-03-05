using System.ComponentModel.DataAnnotations.Schema;

namespace Day1.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FName { get; set; } = string.Empty;
        public string LName {  get; set; } = string.Empty;
        public int Salary {  get; set; }
        public string Img { get; set; } = string.Empty;
        public int Age { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department? Department { get; set; }
            
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
