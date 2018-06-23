using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SalonAutomobila.Models
{
    [Table("Contract")]
    public class Contract
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        [Column("Contract Name")]
        public string Name { get; set; }

        public int CarSalonId { get; set; }
        [ForeignKey("CarSalonId")] // ovde pisemo od klase u ovom slucaju "Engine" kao sto je dole, ako namapiramo na klasu a ne na Id onda naziv ID-ja ovog ispod
        [Column("Salon Name")]
        public CarSalon CarSalon { get; set; }

        
        public int ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")] // ovde pisemo od klase u ovom slucaju "Engine" kao sto je dole, ako namapiramo na klasu a ne na Id onda naziv ID-ja ovog ispod
        [Column("Manufacturer Name")]
        public Manufacturer Manufacturer { get; set; }
    }
}