     var connection = new HubConnection("{enter your hub url}");
     var myHub = connection.CreateHubProxy("ConvHub");
     
     myHub.Invoke("send", "your username").ContinueWith(task => {
                        if (task.IsFaulted)
                        {
                            Console.WriteLine("There was an error calling send: {0}", task.Exception.GetBaseException());
                        }
                        else
                        {
                            Console.WriteLine("Send Complete.");
                        }
                    });
