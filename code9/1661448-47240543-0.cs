       public class Apts
        {
            private ObservableCollection<Apartment> apartments;
            public ObservableCollection<Apartment> Apartments
            {
                get
                {
                    return apartments;
                }
                set
                {
                    apartments = value;
                }
            }
    
            public Apts()
            {
                apartments = new ObservableCollection<Apartment>()
                    {
                        new Apartment() {Name = "Name1", ID = 1},
                        new Apartment() {Name = "Name2", ID = 2},
                        new Apartment() {Name = "Name3", ID = 3},
                    };
            }
        }
