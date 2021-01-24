    drawCalender.OnDateSelected += (object sender, DateChangedEventArgs e) =>
                    {
                        ExtendedDatePicker calendarPicker = (ExtendedDatePicker)sender;
                        if (calendarPicker.NullableDate != null)
                        {
                            CalendarText = (DateTime)calendarPicker.NullableDate;
                        }
                        else
                        {
                            CalendarText = null;
                        }
                    };
