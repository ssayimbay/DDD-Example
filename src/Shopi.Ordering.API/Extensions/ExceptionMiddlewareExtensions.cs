using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shopi.Ordering.Application.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shopi.Ordering.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {

                        string json = string.Empty;
                        if (contextFeature.Error.Data.Count > 0)
                        {
                            json = JsonConvert.SerializeObject(ResponseDto.Fail((List<string>)contextFeature.Error.Data[contextFeature.Error.GetType().Name]));
                        }

                        else
                        {
                            json = JsonConvert.SerializeObject(ResponseDto.Fail(contextFeature.Error.Message));
                        }

                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }
    }
}
