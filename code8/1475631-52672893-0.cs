        public async void ForceRaisePropertyChanged(string propName)
        {
            await Task.Delay(1);
            RaisePropertyChanged(propName);
        }
