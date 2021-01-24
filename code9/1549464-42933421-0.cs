                    Console.WriteLine("Waiting for debugger to attach");
                     if(WeirdBehaviourOccurred)
                       while (!Debugger.IsAttached)
                       {
                          Thread.Sleep(100);
                       }
                    Console.WriteLine("Debugger attached");
