    <CheckBox x:Name="CbAutoRefresh" Checked="CheckBoxChanged" Unchecked="CheckBoxChanged"/>
<!---->
    public class MyWindow()
    {
       private Timer _t;
       public MyWindow()
       {
          InitializeComponent();
          _t = new Timer();
          _t.Elapsed += OnTimedEvent;
          _t.Interval = 60000;
       }
                
       private void CheckBoxChanged(object sender, RoutedEventArgs e)
       {
          _t.Enabled = CbAutoRefresh.IsChecked;
       }    
    }
