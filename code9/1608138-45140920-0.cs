     public string Interact_With_Python(Delegate f)
            {            
                f.DynamicInvoke("Executing Step1");
                Thread.Sleep(1000);
                f.DynamicInvoke("Executing Step2");
                Thread.Sleep(1000);
                f.DynamicInvoke("Executing Step3");
                Thread.Sleep(1000);
                return "Done";
            }
