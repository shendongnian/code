    private void button1_Click(object sender, RibbonControlEventArgs e)
    {
        var t = new Thread(() =>
        {
            var app = new App();
            App.ResourceAssembly = app.GetType().Assembly;
            app.InitializeComponent();
            System.Windows.Threading.Dispatcher.Run();
        });
        t.SetApartmentState(ApartmentState.STA);
        t.Start();
    }
