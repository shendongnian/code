        public class MyViewModel : INotifyPropertyChanged
        {
            //IMPLEMENT INotifyPropertyChanged HERE PLS
            public ObservableCollection<RoundedHour> Collection { get; set; } = new ObservableCollection<RoundedHour>();
            private void AddToCollection(object hrvalueinitially)
            {
                Collection.Add(new RoundedHour()
                {
                    hourvalue = hrvalueinitially.ToString()
                });
                OnPropertyChanged("Collection");
            }
            //Make sure to set your Windows DataContext to an Instance of this Class
        }
   
