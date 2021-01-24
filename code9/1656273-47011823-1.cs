    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // make sure you place this at the top
            // the request pipeline will go in sequence
            app.Use(async (context, next) =>
            {
                // do work for your special case, performance tests, etc
                // in order to short-circuit the pipeline, do NOT call the next parameter 
                // so, you could place some kind of conditional here that will allow only
                // specific requests to continue down/up the pipeline
                if (!true)
                {
                    await next.Invoke();
                }
            });
            // the rest of the pipeline
        }
    }
