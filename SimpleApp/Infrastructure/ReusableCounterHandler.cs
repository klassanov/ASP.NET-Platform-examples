using System;
using System.Web;

namespace SimpleApp.Infrastructure
{
    public class ReusableCounterHandler : IHttpHandler
    {
        private int handlerCounter;
        private int requestCounter=1;
        private int requestNumberLimit = 3;

        public ReusableCounterHandler(int counterValue)
        {
            this.handlerCounter = counterValue;
        }

        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return this.requestCounter < this.requestNumberLimit; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //write your handler implementation here.
          
            context.Response.ContentType = "text/plain";
            context.Response.Write(string.Format("The counter value is {0} (Request {1} of {2})",
                this.handlerCounter, this.requestCounter, this.requestNumberLimit));

            requestCounter++;
        }

        #endregion
    }
}
