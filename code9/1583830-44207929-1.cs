    private void button1_Click(object sender, RibbonControlEventArgs e)
    {
	   var t = new Thread(() =>
       {
           MainWindow window = new MainWindow();
           window.Closed += (s2, e2) => window.Dispatcher.InvokeShutdown();
           window.Show();
           System.Windows.Threading.Dispatcher.Run();
       });
       t.SetApartmentState(ApartmentState.STA);
       t.Start();
    }	
