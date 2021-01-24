    public class ViewModelBase : INotifyPropertyChanged
    {
        bool isBusy;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                SetProperty(ref isBusy, value);
            }
        }
        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <returns><c>true</c>, if property was set, <c>false</c> otherwise.</returns>
        /// <param name="backingStore">Backing store.</param>
        /// <param name="value">Value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <param name="onChanged">On changed.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected bool SetProperty<T>(
            ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
