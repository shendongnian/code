    public class CatalogViewModel: INotifyPropertyChanged
    {
    	    private BaseCommand _selectFileCommand;
            public ICommand SelectFileCommand
            {
                get
                {
                    if (_selectFileCommand == null)
                    {
                        _selectFileCommand = new BaseCommand(SelectFile, CanSelectFile);
                    }
                    return _selectFileCommand;
                }
            }
    ...
