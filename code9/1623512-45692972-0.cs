    static void Main()
            {
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Bootstrap();
                //Get instance of my Registered HomeForm
                Application.Run((container.GetInstance<Home>()));
                
            }
          
    
            private static void Bootstrap()
            {
                // Create the container as usual.
                container = new Container();
    
                // Register my types, for instance:
                container.Register<UnitOfWork, UnitOfWork>();
                //Register my HomeForm
                container.Register<Home>();
               
                // Optionally verify the container.
                //container.Verify();
            }
    
        }
