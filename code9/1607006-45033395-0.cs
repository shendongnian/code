    RegisterEvent<SelectionChangedEventArgs>(
                    (sender, e) =>
                    {
                        if (e == null || !(sender as System.Windows.Controls.Control).IsLoaded)
                        {
                            return;
                        }
                        //Here i got the selection changes
                    },
    handler,handler);
