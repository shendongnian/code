      public partial class MainWindow : Window
      {
          public MainWindow()
         {
              InitializeComponent();
            MyContext myContext = new MyContext();
            myContext.Students = new ObservableCollection<Student>
            {
                new Student{ Name="A", Address="Address1", Age=10},
                new Student{ Name="B", Address="Address2", Age=12},
                new Student{ Name="C", Address="Address3", Age=11},
                new Student{ Name="D", Address="Address4", Age=18},
                new Student{ Name="E", Address="Address5", Age=13},
                new Student{ Name="F", Address="Address6", Age=15},
                new Student{ Name="G", Address="Address7", Age=16},
            };
            this.DataContext = myContext;
        }
    }
