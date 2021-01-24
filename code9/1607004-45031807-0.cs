            RegisterEvent<SelectionChangedEventArgs>(
                (sender, e) =>
                {
                    if (e == null || e.RemovedItems.Count == 0)
                    {
                        return;
                    }
                    //Here i got the selection changes
                }, handler,handler);
