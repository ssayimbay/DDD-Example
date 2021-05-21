using Shopi.Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Ordering.Domain.OrderAggregate
{
    public class Order : Entity,IAggregateRoot
    {
        public int BrandId { get; private set; }
        public int Price { get; private set; }
        public string StoreName { get; private set; }
        public string CustomerName { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order()
        {

        }

        public Order(int branId,int price,string customerName,OrderStatus orderStatus)
        {
            BrandId = branId;
            Price = price;
            CustomerName = customerName;
            Status = orderStatus;
            CreatedOn = DateTime.UtcNow;
        }
    }
}
