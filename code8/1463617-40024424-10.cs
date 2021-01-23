    public class ViewModel
    {
        public ObservableCollection<string> Images { get; }
            = new ObservableCollection<string>(Enumerable
                .Range(1, 151)
                .Select(i => string.Format("pack://application:,,,/Images/{0:000}.png", i)));
    }
