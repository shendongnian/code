    public test1() {
          InitializeComponent();
          ctrTest2.Title = WinTitle;
          //Need to do it after Initialization
          Window win = Application.Current.MainWindow;
          win.WindowStyle = System.Windows.WindowStyle.None;
          win.AllowsTransparency = true;
      }
