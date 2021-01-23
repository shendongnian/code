    public partial class ProgressBarViewModel : INotifyPropertyChanged{
    int _completion;
        public int Completion
        {
            get { return _completion; }
            set
            {
                _completion = value;
                Notify("Completion");
            }
        }
    private string _fileCopied;
    public string FileCopiedString
    {
        get { return _fileCopied; }
        set
        {
            _fileCopied = value;
            Notify("FileCopiedString");
        }
    }
    public void ChangeCompletion(int Value, string file)
    {
        Completion = Value;
        FileCopiedString = FileCopiedString + file;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void Notify(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
