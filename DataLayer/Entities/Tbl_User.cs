using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Tbl_User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string CodeNational { get; set; }
        public string Image { get; set; }
    }
}