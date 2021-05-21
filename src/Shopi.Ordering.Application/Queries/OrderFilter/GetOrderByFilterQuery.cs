using MediatR;
using Shopi.Ordering.Application.Dtos;
using Shopi.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Ordering.Application.Queries.OrderFilter
{
   public class GetOrderByFilterQuery : IRequest<ResponseDataDto<List<OrderDto>>>
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public string SearchText { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<OrderStatus> Statuses { get; set; }
        public string SortBy { get; set; }
    }
}
