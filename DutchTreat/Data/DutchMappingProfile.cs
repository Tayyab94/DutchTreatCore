using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;

namespace DutchTreat.Data
{
    public class DutchMappingProfile:Profile
    {
        public DutchMappingProfile()
        {
            CreateMap<Order, OrderViewModel>().ForMember(x => x.orderId, e => e.MapFrom(x => x.Id)).ReverseMap();

            CreateMap<Product, ProductViewModel>().ForMember(x => x.productId, ep => ep.MapFrom(x => x.Id))
                .ReverseMap();
        }
    }
}
