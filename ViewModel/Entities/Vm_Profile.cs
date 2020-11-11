using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModel.Entities {
    public class Vm_Profile {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public IFormFile ImageUpload { get; set; }

    }
}