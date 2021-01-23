    int count = 100000;
    Task.Factory.StartNew(() => {
        using (var d = Dispatcher.DisableProcessing())
        {
            for (int i = 0; i < count; i++)
            {
                this.Dispatcher.BeginInvoke(new Action(()=> {
                    CreateCtr(i.ToString());
                }));
            }
        }
    });
