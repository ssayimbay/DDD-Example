using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Ordering.Application.Queries.OrderFilter
{
  public class GetOrderByFilterQueryValidator :AbstractValidator<GetOrderByFilterQuery>
    {
        public GetOrderByFilterQueryValidator()
        {
            RuleFor(v => v.PageNumber).NotNull().WithMessage("{PropertyName} required");
            RuleFor(v => v.PageNumber).GreaterThan(0).WithMessage("{PropertyName} must greater than '0'");
            RuleFor(v => v.PageSize).NotNull().WithMessage("{PropertyName} required");
            RuleFor(v => v.PageSize).GreaterThan(0).WithMessage("{PropertyName} must greater than '0'");
            RuleFor(v => v.EndDate).GreaterThan(o => o.StartDate).WithMessage("EndDate must greater than StartDate");
            RuleForEach(v => v.Statuses).IsInEnum().WithMessage("{PropertyName} must be 'Created'='10', 'InProgress'='20', 'Failed'='30', 'Completed'='40', 'Canceled'='50', 'Returned'='60'.");
            RuleFor(o => o.SortBy).Must(SortByFilter).WithMessage("{PropertyName} must be 'Id', 'BrandId', 'Price', 'StoreName', 'CustomerName', 'CreatedOn', 'Status' ");
        }

        private bool SortByFilter(string arg)
        {
            string[] filters = { "Id", "BrandId", "Price", "StoreName", "CustomerName", "CreatedOn", "Status" };
            if (filters.Contains(arg))
            {
                return true;
            }
            return false;
        }
    }
}
