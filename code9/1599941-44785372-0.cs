    using System.Windows.Interactivity;
    
    private bool _xFocus;
    
    public ICommand XGotFocus { get; set; }
    public ICommand XLostFocus { get; set; }
    public ICommand XSend { get; set; }
    
    // In the constructor:
    XGotFocus = new RelayCommand(() => _xFocus = true);
    XLostFocus = new RelayCommand(() => _xFocus = false);
    XSend = new RelayCommand(() => ExecuteXSend());
    // Done with constructor
    private void ExecuteXSend()
    {
        RaisePropertyChanged("Xdro");
        string sendToPort = "X" + Xdro;
        try
        {
            port.WriteLine(sendToPort);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: \r\r" + ex.Message);
        }
        Console.WriteLine("Sending X position: " + sendToPort);
        MotorsMoving = true;
        RaisePropertyChanged("MotorsMoving");
    }
