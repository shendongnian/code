        Within OnCreate, Please note the bool is a class wide variable
          StartTimePickerBTN.Click += delegate
            {
                SelectStartOrEndTime = true;
                OnCreateDialog().Show();
            };
            EndTimePickerBTN.Click += delegate
            {
                SelectStartOrEndTime = false;
                OnCreateDialog().Show();
            };
        protected Dialog OnCreateDialog()
        {
                return new TimePickerDialog(this, TimePickerCallback, hour, minute, false);
        }
        private void TimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            hour = e.HourOfDay;
            minute = e.Minute;
            UpdateTime();
        }
        private void UpdateTime()
        {
            if (SelectStartOrEndTime == true)
            {
                StartTimeTV.Text = string.Format("{0}:{1}", hour, minute.ToString().PadLeft(2, '0'));
            }
            else
            {
                EndTimeTV.Text = string.Format("{0}:{1}", hour, minute.ToString().PadLeft(2, '0'));
            }
            
        }
