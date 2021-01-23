            Thumbtxt.Dispatcher.Invoke(new Action(()=> 
            {
                if (Thumbtxt.Tag != null)
                {
                    if (Thumbtxt.Tag.ToString() == "Disabled")
                        IsDisabled = true;
                };
            }));
