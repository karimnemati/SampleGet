using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Tbl_Profile
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string User { get; set; }

    }
}