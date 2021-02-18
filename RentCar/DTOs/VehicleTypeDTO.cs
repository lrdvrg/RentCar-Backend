using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.DTOs
{
    public class VehicleTypeDTO
    {
        public int VehicleTypeId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}