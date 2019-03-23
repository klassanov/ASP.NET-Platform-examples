using Newtonsoft.Json;
using System;
using System.Web;

namespace SimpleApp.Infrastructure
{
    public class DayOfWeekHandler : IHttpHandler, IRequiresDate
    {
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
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //write your handler implementation here.
            string day;
            //day = DateTime.Now.DayOfWeek.ToString();

            if (context.Items.Contains("DayModule_Time") && context.Items["DayModule_Time"] is DateTime)
            {
                day = ((DateTime)context.Items["DayModule_Time"]).DayOfWeek.ToString();


                if (context.Request.CurrentExecutionFilePathExtension == ".json")
                {
                    context.Response.ContentType = "application/json";
                    context.Response.Write(JsonConvert.SerializeObject(new { Day = day }));
                }
                else
                {
                    context.Response.ContentType = "text/html";
                    context.Response.Write(string.Format("<span>It is: {0}</span>", day));
                }
            }
            else
            {
                context.Response.ContentType = "text/html";
                context.Response.Write("No module data available");
            }
        }

        #endregion
    }
}
