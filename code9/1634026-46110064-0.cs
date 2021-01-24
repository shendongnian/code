    private CheckInModel _checkInModel;
    public ChechInModel CheckInModel
    {
        get { return _checkInModel; }
        set { SetPropery( ref _checkInModel, value ); }
    }
    private void ExecuteClear()
    {
        CheckInModel = new CheckInModel();
    }
    <TextBox Text="{Binding CheckInModel.LastName}"/>
    <Button Content="Cancel and Discard" Command="{Binding ClearCommand}"/>
