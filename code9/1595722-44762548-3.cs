    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Node> nodeList;
        public MainViewModel()
        {
            nodeList = Node.GetSampleNodes();
            DragDeltaCommand = new RelayCommand<DragDeltaEventArgs>(e => OnDeltaDrag(e));
        }
        public ICommand DragDeltaCommand { get; private set; }
        public ObservableCollection<Node> NodeList
        {
            get { return nodeList; }
        }
        private void OnDeltaDrag(DragDeltaEventArgs e)
        {
            Thumb thumb = e.Source as Thumb;
            if (thumb != null)
            {
                Node node = (Node)thumb.DataContext;
                node.X += e.HorizontalChange;
                node.Y += e.VerticalChange;
                RaisePropertyChanged(() => NodeList);
            }
        }
    }
