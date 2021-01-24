    public class TestVM 
        {
            public ObservableCollection<User> Users { get; set; }
    
            public TestVM()
            {
                Users = new ObservableCollection<User>
                {
                    new User{ IsChecked=true, Name="User1" },
                    new User{ IsChecked=false, Name="User2" },
                    new User{ IsChecked=true, Name="User3" },
                    new User{ IsChecked=false, Name="User3" },
                };
            }
        }
        
        public class User
        {
            public bool IsChecked { get; set; }
            public string Name { get; set; }
        }
