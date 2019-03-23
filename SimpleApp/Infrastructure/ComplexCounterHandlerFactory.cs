using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleApp.Infrastructure
{
    public class ComplexCounterHandlerFactory:IHttpHandlerFactory
    {
        private int counter=0;
        private int handlerMaxCount = 3;
        private int handlerCount=0;
        private BlockingCollection<ReusableCounterHandler> pool = new BlockingCollection<ReusableCounterHandler>();
        
        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            ReusableCounterHandler handler;
            if(!pool.TryTake(out handler))
            {
                if (handlerCount < handlerMaxCount)
                {
                    handlerCount++;
                    handler = new ReusableCounterHandler(++counter);
                    pool.Add(handler);
                }
                else
                {
                    handler=pool.Take();
                }
            }
            return handler;
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
            if (handler.IsReusable)
            {
                pool.Add((ReusableCounterHandler)handler);
            }
            else
            {
                handlerCount--;
            }
        }
    }
}