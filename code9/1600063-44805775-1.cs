    internal class MainPageViewModel : INotifyPropertyChanged
    {
        private DateTime selectedDate = DateTime.Now;
        /// <summary>
        /// Backing property for the Selected Date in the Date Picker.k
        /// </summary>
        /// <value>
        /// The selected date.
        /// </value>
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                if (value.Date != selectedDate.Date)
                {
                    selectedDate = value;
                    RaisePropertyChanged(nameof(SelectedDate));
                    RaisePropertyChanged(nameof(SelectedDateString));
                }
            }
        }
        public string SelectedDateString => SelectedDate.ToString("dd MMM yyyy");
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion INotifyPropertyChanged
    }
