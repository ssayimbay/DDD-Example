using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopi.Ordering.Application.Queries.OrderFilter;
using Shopi.Ordering.Application.Commands.OrderImport;

namespace Shopi.Ordering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("Search")]
        public async Task<IActionResult> GetOrders([FromBody] GetOrderByFilterQuery getOrderByFilterQuery)
        {
            var response = await _mediator.Send(getOrderByFilterQuery);

            if (!response.IsSuccessful)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpPost("Import")]
        public async Task<IActionResult> AddRangeAsync([FromBody] OrderImportCommand orderImportCommand)
        {
            var response = await _mediator.Send(orderImportCommand);

            if (!response.IsSuccessful)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
