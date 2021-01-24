    public Page1()
        { 
             InitializeComponent();
             var test1 = Task.Run(() => loadtest());
             var test2 = Task.Run(() => loadtest2());
             Task.WhenAll(test1,test2);
        }
