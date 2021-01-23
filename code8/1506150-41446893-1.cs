    private MyLibraryClass _MyLibraryClass;
    public Form1()
    {
        InitializeComponent();
        _MyLibraryClass = new MyLibraryClass();
        _MyLibraryClass.SynchronizingObject = this;
        _MyLibraryClass.EntryReceived += OnEntryReceived;
    }
    private void OnEntryReceived(object sender, LogEventArgs e)
    {
        myTextBox.Text += e.Entry.Message;
    }
