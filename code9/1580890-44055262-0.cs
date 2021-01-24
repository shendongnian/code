    public class SampleViewModel : ObservableObject
    {
        public SampleViewModel()
        {
        }
        private SampleModel _selectedSample;
        public SampleModel SelectedSample
        {
            get
            {
                return _selectedSample;
            }
            set
            {
                _selectedSample= value;
                NotifyPropertyChanged("SelectedSample");
            }
        }
