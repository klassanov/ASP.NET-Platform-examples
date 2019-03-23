using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleApp.Infrastructure
{
    public class CounterHandlerFactory : IHttpHandlerFactory
    {
        private int counter = 0;

        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            return new CounterHandler(++counter);
        }

        public void ReleaseHandler(IHttpHandler handler)
        {           
        }
    }
}