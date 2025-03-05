using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public int minDegree { get; set; }

        [ForeignKey("Instrutor")]
        public int InstructorId { get; set; }
        public Instructor? instructor { get; set; }
    }
}
