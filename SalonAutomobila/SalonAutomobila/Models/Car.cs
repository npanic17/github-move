using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalonAutomobila.Models
{
    [Table("Car")]
    public class Car
    {

        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Model { get; set; }

        [Required]
        [Range(2000, 2018)]
        public int Year { get; set; }

        [Required]
        [Range(750, 7000)]
        public int EngineVolume { get; set; }

        [Required]
        [StringLength(70)]
        public string Color { get; set; }

        public int ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")] // ovde pisemo od klase u ovom slucaju "Engine" kao sto je dole, ako namapiramo na klasu a ne na Id onda naziv ID-ja ovog ispod
        [Column("Manufacturer Name")]
        public Manufacturer Manufacturer { get; set; }


        public int CarSalonId { get; set; }

        [ForeignKey("CarSalonId")] // ovde pisemo od klase u ovom slucaju "Engine" kao sto je dole, ako namapiramo na klasu a ne na Id onda naziv ID-ja ovog ispod
        [Column("Salon Name")]
        public CarSalon CarSalon { get; set; }

    }
}