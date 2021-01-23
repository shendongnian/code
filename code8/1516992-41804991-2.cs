    public static void StartWindow()
    {
        // MyWindow
        System.Windows.Window win;
        // Load MyWindow
        using (FileStream fs = new FileStream(@"C:\MyWindow.xaml", FileMode.Open))
        {
            object obj = System.Windows.Markup.XamlReader.Load(fs);
            win = (System.Windows.Window)obj;
        }
        win.Loaded += (ss, ee) => 
        {
            //access the containers here...
        };
        win.ShowDialog();
    }
