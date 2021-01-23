    public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                var data = this.DataContext as TestVM;
                data.MyThickness = new Thickness(100,10,20,0);
            }
        }
