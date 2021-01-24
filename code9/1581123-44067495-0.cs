    <i:Interaction.Triggers>
        <i:EventTrigger EventName="MouseLeftButtonDown" >
            <cmd:EventToCommand Command = "{Binding MouseUpCommand}" PassEventArgsToCommand="True" />
        </i:EventTrigger>
    </i:Interaction.Triggers>
----------
    private ICommand _mouseUpCommand;
    public ICommand MouseUpCommand
    {
        get
        {
            if (_mouseUpCommand == null)
            {
                _mouseUpCommand = new RelayCommand<MouseButtonEventArgs>(MouseUpFunc);
            }
            return _mouseUpCommand;
        }
    }
    private void MouseUpFunc(MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
            Debug.Write("double");
        else
            Debug.Write("single");
    }
