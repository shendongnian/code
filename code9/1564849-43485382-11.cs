        public bool SetIfChanged<T>(ref T field, T value, Action RunCalcs, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, value))
            {
                field = value;
                RunCalcs.Invoke();
                RaisePropertyChanged(propertyName);
                return true;
            }
            return false;
        }
