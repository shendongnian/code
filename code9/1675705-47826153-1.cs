    public partial class MainWindow : Window {
      public MainWindow(){
        InitializeComponent();
        this.DataContext = this;
      }
      B b = new B();
      A a = new A(b);
      private void Button_Click(object sender, RoutedEventArgs e) {
          b.Bat = double.Parse(one.Text);
          b.PrintB();
          a.PrintAfromB();
          a.PrintAfromBB();
      }
    }
