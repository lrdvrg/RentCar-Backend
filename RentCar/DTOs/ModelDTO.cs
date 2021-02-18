using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.DTOs
{
    public class ModelDTO
    {
        public int ModelId { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}