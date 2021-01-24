    public partial class Child: Window
    {
        public Child()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello world!");
        }
    // this is what you need to add
        private void Child_Closing(object sender, System.ComponentModel.CancelEventArgs e)     
        {
            this.Owner = null;
        }
    }
