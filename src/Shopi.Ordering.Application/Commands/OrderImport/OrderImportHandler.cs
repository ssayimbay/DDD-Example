using AutoMapper;
using MediatR;
using Shopi.Ordering.Application.Dtos;
using Shopi.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shopi.Ordering.Application.Commands.OrderImport
{
    public class OrderImportHandler : IRequestHandler<OrderImportCommand, ResponseDto>
     {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderImportHandler(IOrderRepository orderRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> Handle(OrderImportCommand request, CancellationToken cancellationToken)
        {
            var orderList = _mapper.Map<List<Order>>(request.orderImportDtos);
            await _orderRepository.AddRangeAsync(orderList);
            return ResponseDto.Success();
        }


    }
}
