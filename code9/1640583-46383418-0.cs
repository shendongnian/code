            public void Init(HttpApplication context)
            {
                context.PostRequestHandlerExecute += new EventHandler(this.ProcessResponse);
            }
            private void ProcessResponse(object sender, EventArgs e)
            {
                HttpContext context = ((HttpApplication)sender).Context;
                //do whatever you want to the context
                //context.Response.Headers.Remove
                }
            }
