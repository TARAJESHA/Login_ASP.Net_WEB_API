using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers.Models
{
    public class ClassRooms
    {
        [Key]
        public int Id { get; set; }
        public string? clasName { get; set; }
        public string? ID { get; set;}
    }
}
