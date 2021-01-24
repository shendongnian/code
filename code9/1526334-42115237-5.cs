    <Button Content="Paste" Click="{Binding Paste}" IsEnabled="{Binding CanPaste}" />
    <MenuItem Header="Paste" Click="{Binding Paste}" IsEnabled="{Binding CanPaste}"/>
    public void Paste() {....}
    private bool _canPaste;
    public bool CanPaste
    {
        get { return _canPaste }
        set 
        { 
            if (_canPaste != value)
            {
                _canPaste = value;
                OnNotifyPropertyChanged(nameof(CanPaste);
            }
        }
    }
