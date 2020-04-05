using AutoMapper;
using Shipnet.Models;
using Shipnet.Models.Entities;
using Shipnet.Models.Resources;
using Shipnet.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipnet.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerEntity,Customer>()
                .ForMember(dest => dest.Self, 
                    opt => opt.MapFrom(src => Link.To(nameof(CustomersController.GetCustomerById)
                                    , new { customerId = src.CustomerId })));

        }
    }
}
