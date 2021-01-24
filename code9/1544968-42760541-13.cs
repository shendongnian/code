    public class MyUserControl
    {
        public MyUserControl()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        public List<MyItem> MySrcList = new List<MyItem>();
        private void dtGConsultas_SelectionChanged( /* args */)
        {
            MyTbx.Text = dtGConsultas.SelectedItem.ToString();
        }
    }
