    public class LeafletListModel: ListModel, INotifyPropertyChanged
    {
        private bool _selected;
        public LeafletListModel(int id, string name, DateTime bpsDrugsUpdated):base(id, name)
        {
            BpsDrugsUpdated = bpsDrugsUpdated;
        }
        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime BpsDrugsUpdated { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
