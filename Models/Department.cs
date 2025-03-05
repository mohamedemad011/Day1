namespace Day1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location {  get; set; }=string.Empty;
        public virtual ICollection<Student> Students { get; set; }=new List<Student>();
        public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}
