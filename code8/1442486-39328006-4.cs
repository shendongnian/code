    public enum MyItemState
    {
        Regular,
        Expanded
    }
    public sealed partial class MyItem : UserControl
    {
        private MyItemState _state;
        public MyItemState State
        {
            get { return _state; }
            set
            {
                _state = value;
                VisualStateManager.GoToState(this, _state.ToString(), true);
            }
        }
        public MyItem()
        {
            InitializeComponent();
            State = MyItemState.Regular;
        }
        private void Title_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (State == MyItemState.Regular)
            {
                State = MyItemState.Expanded;
            }
            else
            {
                State = MyItemState.Regular;
            }
        }
        private void Items_OnItemClick(object sender, ItemClickEventArgs e)
        {
            // action after subitem is clicked
        }
    }
