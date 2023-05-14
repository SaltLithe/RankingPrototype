using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http;

namespace RankingPrototype.Filters
{
    public class RankingExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType().Equals(typeof(HttpResponseException)))
            {
                HttpResponseException exception = (HttpResponseException)context.Exception;
                context.Result = new ObjectResult(exception.Response.Content.ReadAsStringAsync()) { StatusCode = (int?)exception.Response.StatusCode };
            }
        }
    }
}
