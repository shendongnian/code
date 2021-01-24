        #region toolbar commands
        public ICommand ShowCalendarCommand => new RelayCommand<Object>(ShowCalendar);
        #endregion
        private void ShowCalendar(Object obj)
        {
            var calendar = (DatePicker)obj;
            calendar.Focus();
            //  MessagingCenter.Send(this, "Calendar");
        }
