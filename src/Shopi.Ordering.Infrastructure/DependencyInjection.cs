using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopi.Ordering.Domain.OrderAggregate;
using Shopi.Ordering.Domain.SeedWork;
using Shopi.Ordering.Infrastructure.Context;
using Shopi.Ordering.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<OrderDbContext>(options =>
                    options.UseSqlServer(configuration["ConnectionStrings:SqlConStr"],
                        b => b.MigrationsAssembly("Shopi.Ordering.Infrastructure")));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}

