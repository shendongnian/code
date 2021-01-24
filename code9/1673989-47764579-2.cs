        //Change Date by DatePicker
        private void DatePickerChangeSetting_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            DateTimeSettings.SetSystemDateTime(e.NewDate.UtcDateTime);
        }
        //Change Time by TimePicker
        private void tpChangeSetting_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            var currentDate = DateTime.Now.ToUniversalTime();
            var newDateTime = new DateTime(currentDate.Year,
                                           currentDate.Month, 
                                           currentDate.Day, 
                                           e.NewTime.Hours, 
                                           e.NewTime.Minutes, 
                                           e.NewTime.Seconds);
            DateTimeSettings.SetSystemDateTime(newDateTime);
        }
