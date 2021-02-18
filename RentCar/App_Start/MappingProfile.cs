using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using RentCar.DTOs;
using RentCar.Models;

namespace RentCar.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Model, ModelDTO>();
            CreateMap<Brand, BrandDTO>();
            CreateMap<Vehicle, VehicleDTO>();
            CreateMap<VehicleType, VehicleTypeDTO>();
            CreateMap<FuelType, FuelTypeDTO>();
            CreateMap<RentAndRefund, RentAndRefundDTO>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Inspection, InspectionDTO>();
            CreateMap<Client, ClientDTO>();
        }
    }
}