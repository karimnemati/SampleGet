using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Tbl_Pay
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public int Amonnt { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }  

    }
}