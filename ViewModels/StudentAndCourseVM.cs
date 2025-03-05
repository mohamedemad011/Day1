namespace Day1.ViewModels
{
    public class StudentAndCourseVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public List<CourseManyVM> Courses { get; set; } = new List<CourseManyVM>();

        public string? curCookieName = string.Empty;
    }
}
