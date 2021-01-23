        public partial class MainWindow : Window {
            public MainWindow()
            {
                InitializeComponent();
    
                var student = new Student(){ Name = "Ebin"};
                student.Subjects.Add(new SubjectWrapper() { SubjectName="subject1",IsSubjectSelected=true });
                student.Subjects.Add(new SubjectWrapper(){ SubjectName = "subject2", IsSubjectSelected = false});
    
                var student2 = new Student() { Name = "Ravi" };
                student2.Subjects.Add(new SubjectWrapper() { SubjectName = "subject1", IsSubjectSelected = false });
                student2.Subjects.Add(new SubjectWrapper() { SubjectName = "subject2", IsSubjectSelected = true });
    
    
                var list = new List<Student>();
                list.Add(student);
                list.Add(student2);
    
    //Name column adding
                maingrid.Columns.Add(new DataGridTextColumn(){ Header = "name", Binding = new Binding("Name")});
    
    //Subject columns added dynamically
                for (int i = 0; i < list[0].Subjects.Count(); i++) {
                
                    var col = new DataGridCheckBoxColumn();
                    col.Header = list[0].Subjects[i].SubjectName;
                    col.Binding = new Binding("Subjects[" + i.ToString() + "].IsSubjectSelected");
                    maingrid.Columns.Add(col);
                }
    
                maingrid.ItemsSource = list;
                
    
            }
        }
    
    
    
        public class Student
        {
            public string Name { get; set; }
            public int IDNumber { get; set; }
            public ObservableCollection<SubjectWrapper> Subjects { get; set; }
            
            public Student()
            {
                Subjects = new ObservableCollection<WpfApplication1.SubjectWrapper>();
                
            }
        }
        public class SubjectWrapper {
            public string SubjectName { get; set; }
            public bool IsSubjectSelected { get; set; }
        }
