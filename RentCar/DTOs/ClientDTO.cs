using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.DTOs
{
    public class ClientDTO
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string DocumentNo { get; set; }
        public string CreditCard { get; set; }
        public Nullable<int> CreditLimit { get; set; }
        public string ClientType { get; set; }
        public string Status { get; set; }
    }
}