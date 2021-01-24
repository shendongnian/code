       public partial class MainWindow : Window
       {
        public MainWindow()
       {
           InitializeComponent();
           var bla = new ObservableCollection<Car>()
           {
              new Car()
           };
           listview.ItemsSource = bla;
       }
     }
     public class Car
     {
       public Car()
      {
         Path = "bla";
      }
       public string Path { get; set; }
     }
 
