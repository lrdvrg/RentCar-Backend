using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.DTOs
{
    public class RentAndRefundDTO
    {
        public int RentAndRefundId { get; set; }
        public Nullable<System.DateTime> RentDate { get; set; }
        public Nullable<System.DateTime> RefundDate { get; set; }
        public Nullable<int> AmountPerDay { get; set; }
        public Nullable<int> AmountOfDays { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
    }
}