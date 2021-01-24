    public void Configuration(IAppBuilder app)
            {
                ConfigureApp(app);
                //Some other code here
                if (_helper.IsNew())
                {
                    Debug.Write("This is a new guy. Redirect him to the setup page permanently");
                    var ctx = new OwinContext();
                    ctx.Response.Redirect("/Setup");//This is how I redirect from Startip.cs
                }            
                
            }
