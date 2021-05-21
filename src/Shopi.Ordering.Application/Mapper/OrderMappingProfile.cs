using AutoMapper;
using Shopi.Ordering.Application.Dtos;
using Shopi.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Ordering.Application.Mapper
{
    class OrderMappingProfile : Profile
    {

        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
