      public MainWindow()
        {
            InitializeComponent();
            List<Student> stud = new List<Student> {
        new Student {RollNo = 1, Name = "Ankur", marks = 34 },
        new Student {RollNo = 2, Name = "Dhrumit", marks = 79},
        new Student {RollNo = 3, Name = "Mannan", marks = 67 }};
            DataGrid.ItemsSource = stud;
        }
        public class Student
        {
            public int RollNo { get; set; }
            public string Name { get; set; }
            public double marks { get; set; }
        }   
          
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            // execute some code
            var student = (Student)((System.Windows.Controls.DataGridRow)sender).Item;
            MessageBox.Show("RollNo = " + student.RollNo + " Name = " + student.marks + " marks = " + student.marks);
        }
