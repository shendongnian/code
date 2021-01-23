                if (isSFHosted)
                {
                    ServiceRuntime.RegisterServiceAsync("DeliveriesWriteType",
                        context => new WebAPI(context, loggerFactory, servicesPreRegister)).GetAwaiter().GetResult();
                }
                else
                {
                    loggerFactory.AddConsole();
                    // run with local web listener with out SF
