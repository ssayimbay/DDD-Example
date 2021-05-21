using Shopi.Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Ordering.Domain.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
