    public ICommand ButtonClickCommand 
    {
        get { return new DelegateCommand<object>(FuncToCall, FuncToEvaluate);}
    }
    private void FuncToCall(object context)
    {
        //this is called when the button is clicked
        MessageBox.Show("Success!");
    }
    private bool FuncToEvaluate(object context)
    {
        //this is called to evaluate whether FuncToCall can be called
        //for example you can return true or false based on some validation logic
        return true;
    }
