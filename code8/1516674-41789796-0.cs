    // if you want runtime changes to be reflected in the UI
    public class ItemVM : INotifyPropertyChanged 
    {
        public string Text { // raise property change in setter }
        public Color BackgroundColor { // whatever you need }
    }
