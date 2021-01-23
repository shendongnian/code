    public class ViewModel
        {
            public ObservableCollection<Country> Countries { get; set; }
    
            public ViewModel()
            {
                Countries = new ObservableCollection<Country>();
                Countries.Add(new Country()
                {
                    Name = "India",
                    States = new ObservableCollection<State>() 
                    { new State()
                        { 
                            Name="MP",
                            Cities = new ObservableCollection<City>()
                            {
                                new City(){Name = "Bhopal"},new City(){Name = "Indore"}, new City(){Name = "Ujjain"}
                            }
                        } ,
                        new State()
                        { 
                            Name="UP",
                            Cities = new ObservableCollection<City>()
                            {
                                new City(){Name = "Agra"},new City(){Name = "Noida"}, new City(){Name = "Jhansi"}
                            }
                        } ,
                        new State()
                        { 
                            Name="AP",
                            Cities = new ObservableCollection<City>()
                            {
                                new City(){Name = "Hyderabad"},new City(){Name = "Warangal"}, new City(){Name = "Vijaywada"}
                            }
                        } 
                    }
                });
                Countries.Add(new Country()
                {
                    Name = "Australia",
                    States = new ObservableCollection<State>() 
                    { new State()
                        { 
                            Name="Tasmania",
                            Cities = new ObservableCollection<City>()
                            {
                                new City(){Name = "Sydney"},new City(){Name = "Melbourne"}
                            }
                        } 
                    }
                });
            }
    
           
        }
    
        public class Country
        {
            public string Name { get; set; }
            public ObservableCollection<State> States { get; set; }
        }
    
        public class State
        {
            public string Name { get; set; }
            public ObservableCollection<City> Cities { get; set; }
        }
    
        public class City
        {
            public string Name { get; set; }
        }
