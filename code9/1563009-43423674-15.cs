    > Injects INotifyPropertyChanged code into properties at compile time
    
    here is the new code after you download the library from the [Nuget](https://www.nuget.org/packages/PropertyChanged.Fody/)
        [PropertyChanged.ImplementPropertyChanged]
        public class Data
        {
            public int FirstNumber { get; set; }
            public int SecondNumber { get; set; }
            public int Sum => SecondNumber + FirstNumber;
        }
