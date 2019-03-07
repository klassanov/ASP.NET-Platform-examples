﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SimpleApp.Infrastructure
{
    public class RequestTimerEventArgs: EventArgs
    {
        public float Duration { get; set; }
    }

    public class TimerModule : IHttpModule
    {
        public event EventHandler<RequestTimerEventArgs> RequestTimed;
        private Stopwatch timer;


        public void Init(HttpApplication app)
        {
            app.BeginRequest += HandleEvent;
            app.EndRequest += HandleEvent;
        }

        public void Dispose()
        {
            // release resources
        }

        private void HandleEvent(object src, EventArgs args)
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx.CurrentNotification == RequestNotification.BeginRequest)
            {
                timer = Stopwatch.StartNew();
            }
            else
            {
                float duration=((float)timer.ElapsedTicks) / Stopwatch.Frequency;
                ctx.Response.Write(
                    string.Format(
                        "<div class='alert alert-success'>Elapsed:{0:F5} seconds</div>",
                        ((float) timer.ElapsedTicks) / Stopwatch.Frequency));

                RequestTimed?.Invoke(this, new RequestTimerEventArgs { Duration = duration });
            }

        }
    }
}