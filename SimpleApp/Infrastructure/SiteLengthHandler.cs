using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SimpleApp.Infrastructure
{
    public class SiteLengthHandler : HttpTaskAsyncHandler
    {
        public override async Task ProcessRequestAsync(HttpContext context)
        {
            string mySite = "http://prevodilegalizacia.bg";
            string data = await new HttpClient().GetStringAsync(mySite);
            context.Response.ContentType = "text/html";
            context.Response.Write(string.Format("<span> The length of {0} is {1} bytes </span>", mySite, data.Length));
        }
    }
}