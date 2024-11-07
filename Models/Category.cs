namespace StudentManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; } 
        public ICollection<Student>? Students { get; set; }
    }


}
