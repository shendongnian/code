    //  ASP.Net Identity Registrations
                        /*
                        b.Register(context => new UserStore<User>(context.Resolve<IDocumentSession>))
                            .AsImplemented‌​Interfaces()
                            .Instanc‌​ePerRequest()
                            .OnRelease(x =>  
                            {  
                                x.Dispose();
                            });
                                    
                        b.Register<IdentityFactoryOptions<ApplicationUserManager>>(c => 
                            new IdentityFactoryOptions<ApplicationUserManager>() { 
                                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionPr‌​ovider("ApplicationName") 
                        }); 
    
                        b.RegisterType<ApplicationUserManager>().AsSelf().Inst‌​ancePerRequest();
                        b.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
                        b.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
                        b.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();
                        */
    
                        b.Register(c => new UserStore<User>(c.Resolve<IDocumentSession>())).As<IUserStore<User>>().InstancePerRequest()
                            .OnRelease(x =>  
                            {  
                                x.Dispose();
                            });
                        b.RegisterType<ApplicationUserManager>().InstancePerRequest();
                        b.RegisterType<ApplicationSignInManager>().InstancePerRequest();
                        b.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
                        b.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();
