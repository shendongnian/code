    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // make sure you place this at the top
            // the request pipeline will go in sequence
            app.Use(async (context, next) =>
            {
                // do work for your special case
                // do NOT call the next to short-circuit the pipeline
                // so place some condition here that will allow only
                // specific requests to continue down/up the pipeline
                if (!true)
                {
                    await next.Invoke();
                }
            });
            // the rest of the pipeline
        }
    }
