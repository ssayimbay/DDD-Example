using AutoMapper;
using MediatR;
using Shopi.Ordering.Application.Dtos;
using Shopi.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shopi.Ordering.Application.Queries.OrderFilter
{
    public class GetOrderByFilterQueryHandler : IRequestHandler<GetOrderByFilterQuery, ResponseDataDto<List<OrderDto>>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByFilterQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public Task<ResponseDataDto<List<OrderDto>>> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
        {
            
            if (request.EndDate == null || request.StartDate == null)
            {
                request.EndDate = DateTime.UtcNow;
                request.StartDate = DateTime.UtcNow.AddMonths(-1);
            }

            var orders =  _orderRepository
                .Where(order => order.StoreName == request.SearchText || order.CustomerName == request.SearchText)
                .Where(order => request.StartDate <= order.CreatedOn && request.EndDate >= order.CreatedOn)
                .Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize)
                .AsEnumerable()
                .OrderBy(x => x.GetType().GetRuntimeProperty(request.SortBy).GetValue(x, null))
                .ToList();

            var ordersDto = _mapper.Map<List<OrderDto>>(orders);

            return  Task.FromResult(ResponseDataDto<List<OrderDto>>.Success(ordersDto));
        }
    }
}
