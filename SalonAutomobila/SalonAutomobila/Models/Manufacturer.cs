using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalonAutomobila.Models
{
    [Table("Manufacturer")]
    public class Manufacturer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        [StringLength(70)]
        public string Country { get; set; }

        [Required]
        [StringLength(70)]
        public string City { get; set; }

        public List<Car> ListCars { get; set; }

        public List<Contract> ListContracts { get; set; }
    }
}