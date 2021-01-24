    public class MultiPlexModel : INotifyPropertyChanged
    {
        private bool isActive;
        private bool isActiveChanging;
        private string name;
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public bool IsActive
        {
            get { return isActive; }
            private set
            {
                isActive = value;
                Notify();
            }
        }
        public bool IsActiveChanging
        {
            get { return isActiveChanging; }
            private set
            {
                isActiveChanging = value;
                Notify();
            }
        }
        public string Name
        {
            get { return name; }
            private set
            {
                name = value;
                Notify();
            }
        }
        public async Task StartMultiplexModelAsync(string newName)
        {
            await Task.Run(async () =>
            {
                if (IsActiveChanging)
                    return;
                IsActiveChanging = true;
                await Task.Delay(2000);
                Name = newName;
                IsActive = true;
                IsActiveChanging = false;
            });
        }
        public async Task StopMultiplexModelAsync()
        {
            await Task.Run(async () =>
            {
                if (IsActiveChanging)
                    return;
                IsActiveChanging = true;
                await Task.Delay(2000);
                Name = string.Empty;
                IsActive = false;
                IsActiveChanging = false;
            });
        }
    }
