using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities
{
    public class TableOrder
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        //public DateTime Date { get; set; }
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Phone { get; set; }
        [MaxLength(5000)]
        public string Message { get; set; }
    }
}
