using FluentValidation;
using Shopi.Ordering.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Ordering.Application.Commands.OrderImport
{


    public class OrderImportValidator : AbstractValidator<OrderImportCommand>
    {
        public OrderImportValidator()
        {
            RuleForEach(x => x.orderImportDtos).ChildRules(x =>
            {
                x.RuleFor(o => o.CustomerName).NotNull().NotEmpty().WithMessage("{PropertyName} required");
                x.RuleFor(o => o.StoreName).NotNull().NotEmpty().WithMessage("{PropertyName} required");
                x.RuleFor(o => o.Status).NotNull().WithMessage("{PropertyName} required");
                x.RuleFor(o => o.Status).IsInEnum().WithMessage("{PropertyName} must be 'Created'='10', 'InProgress'='20', 'Failed'='30', 'Completed'='40', 'Canceled'='50', 'Returned'='60'.");

            });
        }
    }
}
