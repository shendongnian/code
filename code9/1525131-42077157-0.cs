        public class EmployeeViewModel
        {
            private testdbEntities context = new testdbEntities();
    
            public ListCollectionView Employees { get; set; }
            
            public EmployeeViewModel()
            {
                LoadData();
            }
            
            private void LoadData()
            {
                IEnumerable<Employees> query = (from e in context.Employees
                                                orderby e.Lastname
                                                select e);
    
                ObservableCollection<Employees> emp = new ObservableCollection<Employees>(query);
                Employees = new ListCollectionView(emp);
            }
    
        }
    }
