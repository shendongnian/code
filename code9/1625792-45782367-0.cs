     public class EmployeeViewModel
        {
            public EmployeeViewModel()
            {
                SelectedSkills=new List<int>();
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public List<int> SelectedSkills { get; set; }
        }
 
       public class Skills
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
