    public class ViewModel : Notifier
    {
        public ObservableCollection<String> Messages
        {
            get { return Get<ObservableCollection<String>>(); }
            set
            {
                Set(value); 
                Notify(() => AreThereMessages);
            }
        }
        public bool AreThereMessages => Messages?.Count > 0;
    }
