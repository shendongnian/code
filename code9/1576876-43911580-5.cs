    class Program {
        static void Main() {
            var s = new EventStruct();            
            Bind(s);
            s.Property = "test";
            Console.ReadKey();
        }
        static void Bind(INotifyPropertyChanged item) {
            // this is not the same instance of EventStruct,
            // it's a copy, and event will never be fired on this copy
            item.PropertyChanged += OnPropertyChanged;
        }
        private static void OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
            Console.WriteLine(e.PropertyName + " changed");
        }        
    }
