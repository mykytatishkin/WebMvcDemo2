using System.ComponentModel.DataAnnotations;

namespace WebMvcDemo2.Models
{
    public class Library
    {
        public int Id { get; set; }
        [StringLength(2000)]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
