    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MyViewModel() => MySingleton.Instance.PropertyChanged += (s, e) =>
                                {
                                    if (e.PropertyName == nameof(MySingleton.Owners))
                                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Owners)));
                                };
        public IEnumerable<Owner> Owners => MySingleton.Instance.Owners;
    } 
   
