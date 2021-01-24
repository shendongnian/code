    public RelayCommand SaveCommand {
        get {
            return new RelayCommand(OnSave, CanSave);
        }
    }
