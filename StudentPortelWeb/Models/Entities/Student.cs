using System.ComponentModel.DataAnnotations;

namespace StudentPortelWeb.Models.Entities
{
    public class Student
    {
        [Key]
        public Guid sid {get; set; }
        public string  Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Place{ get; set; }
        public bool Subscribed { get; set; }

    }
}
