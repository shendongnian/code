    public class CarsViewModel : INotifyPropertyChanged {
        private ObservableCollection<Car> items;
        public ObservableCollection<Car> Items {
            get { return items; }
            set {
                items = value;
            }
        }
        public CarsViewModel() {
            // Here you can have your data form db or something else,
            // some data that you already have to put in the list
            Items = new ObservableCollection<Car>() {
                new Car()
                {
                    CarID = 1,
                    Make = "Tesla Model S",
                    YearOfModel = 2015
                },
                  new Car()
                {
                    CarID = 2,
                    Make = "Audi R8",
                    YearOfModel = 2012
                },
            };
        }
    }
