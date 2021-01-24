    .ConfigureLogging((context, logging) =>
    {
        logging.AddConfiguration(context.Configuration.GetSection("Logging"));
        if (context.HostingEnvironment.IsDevelopment())
        {
            logging.AddConsole();
            logging.AddDebug();
        }
    });
