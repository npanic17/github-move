using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SalonAutomobila.Models
{
    public class SalonContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<CarSalon> CarSalon { get; set; }
        public DbSet<Contract> Contract { get; set; }

        public SalonContext() : base("name = CarSalonContext")
        {

        }
    }
}