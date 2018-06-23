using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalonAutomobila.Models
{
    [Table("Salon")]
    public class CarSalon
    {
        public int Id { get; set; } // ili CarId - nije bitna konvencija CaseSensitive bice automatski identity po konvenciji i ovo ce biti privatni kljuc

        [Required]
        public string PIB { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        [StringLength(70)]
        public string Country { get; set; }

        [Required]
        [StringLength(70)]
        public string City { get; set; }

        [Required]
        [StringLength(70)]
        public string Address { get; set; }

        public List<Car> ListCars { get; set; }

        public List<Contract> ListContracts { get; set; }

    }
}