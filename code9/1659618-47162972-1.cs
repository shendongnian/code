    private BackgroundWorker worker;
    private RelayCommand instigateWorkCommand;  //CHANGE HERE
    bool isBusy = false;  // ADD THIS
    public ProggressbarSampleViewModel()
    {
        //CHANGE NEXT LINE
        this.instigateWorkCommand = new
                      RelayCommand(o => this.worker.RunWorkerAsync(), o => !isBusy && canLoadWordDoc(null));
        this.worker = new BackgroundWorker();
        this.worker.DoWork += this.DoWork;
        //REMOVE
        //this.worker.ProgressChanged += this.ProgressChanged;
    }
    public ICommand InstigateWorkCommand
    {
        get { return this.instigateWorkCommand; }
    }
    private int _currentProgress;
    public int CurrentProgress
    {
        get { return this._currentProgress; }
        private set
        {
            if (this._currentProgress != value)
            {
                this._currentProgress = value;
                OnPropertyChanged("CurrentProgress");
            }
        }
    }
    //REMOVE
    //private void ProgressChanged(object sender, ProgressChangedEventArgs e)
    //{
    //    this.CurrentProgress = e.ProgressPercentage;
    //}
    private void DoWork(object sender, DoWorkEventArgs e)
    {
        isBusy = true;  // ADD THIS
        // do time-consuming work here, calling ReportProgress as and when you can   
        for (int i = 0; i <= 100; i++)
        {
            Application.Current.Dispatcher.BeginInvoke(
                (Action)instigateWorkCommand.RaiseCanExecuteChanged);  //ADD THIS
            Thread.Sleep(10);
            _currentProgress = i;
            OnPropertyChanged("CurrentProgress");
        }
        //ADD NEXT LINES
        isBusy = false;  
        Application.Current.Dispatcher.BeginInvoke(
            (Action)instigateWorkCommand.RaiseCanExecuteChanged);
    }
    bool m_fileSelected = true;  //TO SEE THE EFFECT
    //REMOVE
    //RelayCommand m_loadWordDocCmd;
    ///// <summary>
    ///// Relaycommand for Function loadWordDocument
    ///// </summary>
    //public RelayCommand LoadWordDocCmd
    //{
    //    get
    //    {
    //        if (this.m_loadWordDocCmd == null)
    //        {
    //            this.m_loadWordDocCmd = new RelayCommand(this.loadWordDocument, canLoadWordDoc);
    //        }
    //        return m_loadWordDocCmd;
    //    }
    //    private set
    //    {
    //        this.m_loadWordDocCmd = value;
    //    }
    //}
    /// <summary>
    /// checks if the Word Document can be loaded
    /// </summary>
    /// <param name="parameter">not used</param>
    /// <returns>if it could Execute, then true, else false</returns>
    private bool canLoadWordDoc(object parameter)
    {
        bool ret = false;
        if (this.m_fileSelected)
        {
            ret = true;
        }
        return ret;
    }
    /// <summary>
    /// Function for Load Word Document
    /// </summary>
    /// <param name="parameter">not used</param>
    private void loadWordDocument(object parameter)
    {
    }
