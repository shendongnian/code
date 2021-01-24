    public delegate void MyEventHandler(object sender, MyEventArgs2 e);
    public event MyEventHandler ItemBeginningEdit;                ^
    public event MyEventHandler ItemCommited;                     |
    public event MyEventHandler ItemEditCancelled;                |
    ...
