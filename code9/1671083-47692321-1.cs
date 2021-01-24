    namespace WpfApplication1
    {
    public class Student
    {
        public string Name { get; set; }
        public int Semester { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Math { get; set; }
    };
    public class MyViewmodel
    {
        public MyViewmodel()
        {
            Students = new ObservableCollection<Student>
            {   
                new Student { Name="John", Semester = 1, Physics = 50, Chemistry = 60, Math = 70 },
                new Student { Name="Tim", Semester = 2, Physics = 80, Chemistry = 50, Math = 70 },
                new Student { Name="Aaron", Semester = 3, Physics = 40, Chemistry = 90, Math = 70 }
            };
        }
        public ObservableCollection<Student> Students { get; set; }
    };
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }       
    }
    }
