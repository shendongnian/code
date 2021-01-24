    public partial class MyPage
    {
        private MyViewModel _viewModel;
        public MyPage()
        {
            InitializeComponent();
        }
    
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            _viewModel = BindingContext as MyViewModel;
            var collection = _viewModel.MyCollection;
        }
      
    }
