    public partial class App : Application
    {
        private CommonState _state;
    
        protected override void OnStartup(StartupEventArgs e)
        {
            _state = new CommonState() {IsChecked = true};
    
            var wndA = new WindowA() { CommonState = _state };
            var wndB = new WindowB() { CommonState = _state };
    
            wndA.Show();
            wndB.Show();
        }
    }
