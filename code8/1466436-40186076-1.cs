    public sealed partial class FirstView : MvxWindowsPage
    {
        public new FirstViewModel ViewModel => base.ViewModel as FirstViewModel;
    
        public FirstView()
        {
            this.InitializeComponent();
        }
    }
