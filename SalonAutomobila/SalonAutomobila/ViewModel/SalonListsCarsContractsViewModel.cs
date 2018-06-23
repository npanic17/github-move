using SalonAutomobila.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonAutomobila.ViewModel
{
    public class SalonListsCarsContractsViewModel
    {
        public CarSalon CarSalons { get; set; }
        public List<Car> ListCars { get; set; }
        public List<Contract> ListContracts { get; set; }
    }
}