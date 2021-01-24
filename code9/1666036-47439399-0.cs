    Thread thd = new Thread(() =>
                {
                    
                    //Do Some stuff 
                    //Do some more stuff
					
                    var dispatcher = Dispatcher.CurrentDispatcher;
                    dispatcher.UnhandledException += Dispatcher_UnhandledException; //you exception handling logic
                    Dispatcher.Run();
                });
                thd.IsBackground = true;
                thd.SetApartmentState(ApartmentState.STA);
                thd.Start();
