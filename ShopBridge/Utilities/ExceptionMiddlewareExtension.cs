#region Namespace

using ShopBridge.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

#endregion

namespace ShopBridge.Utilities
{
    /// <summary>
    /// This class is used to handle exceptions globally 
    /// </summary>
    public static class ExceptionMiddlewareExtension
    {
        /// <summary>
        /// This method is used to Configure the Exception Handler
        /// </summary>
        /// <param name="app">IApplicationBuilder object</param>
        /// <param name="appl">IApplicationBuilder object</param>
        /// <param name="logger">ILog object</param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IApplicationBuilder appl, ILog logger)
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
                        logger.Error(contextFeature.Error);

                        var response = new ResponseDto
                        {
                            Code = context.Response.StatusCode.ToString(),
                            Data = new Data
                            {
                                Response = new Response()
                                {
                                    ReasonCode = Common.FAIL_VAL,
                                    ReasonText = Common.FAIL,
                                    DataList = Common.EMPTY_STRING,
                                    Error = contextFeature.Error.Message.ToString()
                                }
                            }
                        };

                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(response);

                        await context.Response.WriteAsync(data.ToString());
                    }
                });
            });
        }
    }
}  
