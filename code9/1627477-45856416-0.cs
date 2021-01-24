    public void x(FileSummarizer fs) 
    {
       test = new VirtualizingCollection<LinesSummary>(fs, 100);
       // Now you need to raise an event to notify the view.
       // This line depends on if you are implementing INotifyPropertyChanged
       // on your ViewModel directly or if you are yousing some ViewModel-Base
       // class. Here's an example how it could look like:
       RaisePropertyChanged("test");
    }
