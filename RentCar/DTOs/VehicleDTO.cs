using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.DTOs
{
    public class VehicleDTO
    {
        public int VehicleId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ChasisNo { get; set; }
        public string MotorNo { get; set; }
        public string PlateNo { get; set; }
        public Nullable<int> VehicleTypeId { get; set; }
        public Nullable<int> BrandId { get; set; }
        public Nullable<int> ModelId { get; set; }
        public Nullable<int> FuelTypeId { get; set; }
    }
}