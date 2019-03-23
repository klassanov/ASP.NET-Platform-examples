using System;
using System.Web;

namespace SimpleApp.Infrastructure
{
    public class BrowserTypeHandlerFactory : IHttpHandlerFactory
    {
        private int counter;

        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            if (context.Request.UserAgent.Contains("Chrome"))
            {
                return new CounterHandler(++counter);
            }
            else
            {
                return new SiteLengthHandler();
            }
        }
        
        public void ReleaseHandler(IHttpHandler handler)
        {           
        }
    }
}
