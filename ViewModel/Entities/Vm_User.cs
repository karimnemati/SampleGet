using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModel.Entities {
    public class Vm_User {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string CodeNational { get; set; }
        public string Image { get; set; }
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public IFormFile FileUpload { get; set; }
        public string VideoName { get; set; }
        public IFormFile VideoUpload { get; set; }
        public string Description { get; set; }

    }
}