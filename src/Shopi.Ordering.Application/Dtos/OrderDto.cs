using Shopi.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Ordering.Application.Dtos
{
   public class OrderDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int Price { get; set; }
        public string StoreName { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedOn { get; set; }
        public OrderStatus Status { get; set; }
    }
}
