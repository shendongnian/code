    <cmd:EventToCommand Command="{Binding Mode=OneWay, 
        Path=MouseDownCommand}"  PassEventArgsToCommand="True" />
    public RelayCommand<MouseButtonEventArgs> MouseDownCommand
    {
        get
        {
            ...
        }
    }
