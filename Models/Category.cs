namespace StudentManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; } // or string? Name { get; set; }
        public ICollection<Student>? Students { get; set; } // or ICollection<Student> Students { get; set; } = new List<Student>();
    }


}
