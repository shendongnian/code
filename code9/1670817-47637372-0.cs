    public bool IsAlive {
        get { return _isAlive; }
        set {
            bool newValue = SetNotify(ref _isAlive, value);
            if (newValue) {
                var properties = GetType().GetProperties();
                foreach (var property in properties) {
                    if (property != null && property.PropertyType == typeof(DelegateCommand)) {
                        var command = (DelegateCommand)property.GetValue(this, null);
                        command.RaiseCanExecuteChanged();
                        Console.WriteLine("Raised!");
                    }
                }
            }
        }
    }
