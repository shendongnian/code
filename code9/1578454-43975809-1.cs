    public class ViewModel {
        public System.Collections.ObjectModel.ObservableCollection<Model.Root> List { get; set; }
        public ViewModel() {
            List = new System.Collections.ObjectModel.ObservableCollection<Model.Root> {
                new Model.Root {
                    Name = "Peter",
                    Employee = new Model.Employee {
                        ID = 1,
                        Department = "IT"
                    }
                },
                new Model.Root {
                    Name = "Hans",
                    Employee = new Model.Employee {
                        ID = 2,
                        Department = "accounting"
                    }
                },
                new Model.Root {
                    Name = "Bilbo",
                    Employee = new Model.Employee {
                        ID = 3,
                        Department = "ceo"
                    }
                }
            };
        }
    }
