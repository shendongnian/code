        private bool _isCompleted = false;
        public bool IsCompleted { 
            get { return _isCompleted; }
            set {
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                    if (_isCompleted)
                        OnCompleted();
                    OnPropertyChanged();
                }
            }
        }
        //  Purists may argue that an event handler's "args" parameter should always 
        //  inherit from EventArgs, and they may be right, but it's no capital crime. 
        public event EventHandler<NotificationObject> Completed;
        private void OnCompleted() {
            if (Completed != null) {
                Completed(this, this);
            }
        }
    The main viewmodel's handler for that one:
        void note_Completed(object sender, NotificationObject note)
        {
            Notes.Remove(note);
        }
    It sets that up when it creates the `NotificationObject` instances and populates `Notes` with them. 
    It might be better, instead, to simply filter the items shown in the ListBox by `IsCompleted`, depending on your requirements. 
