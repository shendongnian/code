     public partial class Parent: Window
        {
            public Parent()
            {
                InitializeComponent();
            }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Child child = new Child();
            child.Show();
            child.Owner = this;
        }
    }
