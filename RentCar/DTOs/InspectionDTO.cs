using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.DTOs
{
    public class InspectionDTO
    {
        public int InspectionId { get; set; }
        public string Fuel { get; set; }
        public string HaveGrated { get; set; }
        public string HaveReplacementTyre { get; set; }
        public string HaveJack { get; set; }
        public string HaveWindowCrack { get; set; }
        public string FLTyreStatus { get; set; }
        public string FRTyreStatus { get; set; }
        public string RLTyreStatus { get; set; }
        public string RRTyreStatus { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Status { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
    }
}