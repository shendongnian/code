	public partial class Login : INotifyPropertyChanged
    {
	    private bool _busy = true;
	    public event PropertyChangedEventHandler PropertyChanged;
        public bool Busy
	    {
	        get { return _busy; }
	        set
	        {
	            _busy = value;
	            RaisePropertyChanged("Busy");
	        }
	    }
	    private bool NotBusy => !Busy;
        public Login()
	    {
	        InitializeComponent();
	        BindingContext = this;
	        Busy = false;
	    }
        private async void BtnLogin_OnClicked(object sender, EventArgs e)
	    {
	        Busy = true;
	        
            await Task.Delay(120); // gives UI a chance to show the spinner
            // do async login here
            var cts = new CancellationTokenSource();
            var ct = cts.Token;
            var response = Task.Factory.StartNew(() => YourAuthenticationClass.YourLoginMethod(txtUserId.Text, txtPassword.Text).Result, ct);
            // check response, handle accordingly
        }
	    private void RaisePropertyChanged(string propName)
	    {
            System.Diagnostics.Debug.WriteLine("RaisePropertyChanged('" + propName + "')");
	        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
	    }
    }
