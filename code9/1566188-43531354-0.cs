       static void Main(string[] args)
            {
                Task my_task = Task.Factory.StartNew(() => { throw null; });
    
                my_task.ContinueWith(x =>
                {
    
                    if (my_task.IsFaulted)
                    {
                        Console.WriteLine(my_task.Exception.Message);
    
                    }
                    else {
                        //Continue with Execution
                    }
                });
            }
