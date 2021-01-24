        public void SetIfChanged<T>(ref T field, T value, Action RunCalcs, [CallerMemberName] string propertyName = null)
        {
            if (!field.Equals(value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
                RunCalcs.Invoke();
            }
        }
