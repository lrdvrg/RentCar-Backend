using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string DocumentNo { get; set; }
        public string BatchLabor { get; set; }
        public string CommissionPercentage { get; set; }
        public string AdmissionDate { get; set; }
        public string Status { get; set; }
    }
}