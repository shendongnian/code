    public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddNodeServices();
            }
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                loggerFactory.AddConsole();
    
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
    
                app.Run(async (context) =>
                {
                    INodeServices nodeServices = context.RequestServices.GetService<INodeServices>();
    
                    var inputJS = @"(function(){
                                        var variable1 = '5' - 3;
                                        var variable2 = '5' + 3;
                                        var variable3 = '5' + - '2';
                                        console.log(variable1);
                                        console.log(variable2);
                                        console.log(variable3);
                                    })();";
    
                    try
                    {
                        var result = await nodeServices.InvokeAsync<string>("./obfuscate", inputJS);
    
                        context.Response.ContentType = "application/javascript";
    
                        context.Response.StatusCode = 200;
    
                        await context.Response.WriteAsync(result);
                    }
                    catch (Exception e)
                    {
    
                        throw;
                    }
                    
                });
            }
        }
