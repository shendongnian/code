     loggerFactory.AddSerilog();
     if (env.IsDevelopment())
     {
       loggerFactory.AddConsole(Configuration.GetSection("Logging"));
     }
