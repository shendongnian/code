    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WpfTestTreeView
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            
            private ObservableCollection<Department> _departments;
    
            public MainWindow()
            {
                InitializeComponent();
    
                // This is a long winded way but it shows the mechanics of the collections 
    
                _departments = new ObservableCollection<Department>();
                //Create New Depaertment and Student objects
                Department d1 = new Department("A");
                Student s1 = new Student("John","1");
                // Add the Student to the Department Student List
                d1.Students.Add(s1);
                Student s2 = new Student("Rocky", "4");
                // Add the Student to the Department Student List
                d1.Students.Add(s2);
                Student s3 = new Student("Donald", "6");
                // Add the Student to the Department Student List
                d1.Students.Add(s3);
                // Add the Department to The Departments List
                Departments.Add(d1);
    
                Department d2 = new Department("B");
                Student s4 = new Student("Tony", "2");
                d2.Students.Add(s4);
                Departments.Add(d2);
    
                Department d3 = new Department("C");
                Student s5 = new Student("Jai", "3");
                d3.Students.Add(s5);
                Student s6 = new Student("Mickey", "5");
                d3.Students.Add(s6);
                Departments.Add(d3);
    
                // set itemsource on the treeview
                tvDepts.DataContext = Departments;
                tvDepts.ItemsSource = Departments;
    
            }
    
            public ObservableCollection<Department> Departments
            {
                get { return _departments; }
                set { _departments = value; }
            }
        }
    
        // Department Class Holds a Collection of Students
        public class Department
        {
    
            private ObservableCollection<Student> _students;
    
            public Department(string name)
            {
                _students = new ObservableCollection<Student>();
    
                Name = name;
            }
    
            public string Name { get; set; }
            /// <summary>
            /// Collection Of Student in the Department
            /// </summary>
            public ObservableCollection<Student> Students
            {
                get { return _students; }
                set { _students = value; }
            }
        }
    // Student Class
        public class Student
        {
            public Student(string name, string code)
            {
                StudentName = name;
                Code = code;
            }
            public string StudentName { get; set; }
            public string Code { get; set; }
        }
    }
