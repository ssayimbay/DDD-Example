using MediatR;
using Shopi.Ordering.Application.Dtos;
using Shopi.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Ordering.Application.Commands.OrderImport
{
    public class OrderImportCommand : IRequest<ResponseDto>
    {
        public List<OrderDto> orderImportDtos { get; set; }
    }
}
