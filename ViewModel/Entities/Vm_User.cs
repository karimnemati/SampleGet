using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModel.Entities
{
    public class Vm_User
    {
          [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string CodeNational { get; set; }
        public string Image { get; set; }
        public IFormFile File { get; set; }
    }
}