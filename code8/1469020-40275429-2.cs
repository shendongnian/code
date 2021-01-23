    protected Task ChangeCalendar(CalandarChanges changes)
        {
            try
            {
                if (changes.HasFlag(CalandarChanges.StartDate))
                {
                    Device.BeginInvokeOnMainThread(() => CenterLabel.Text = StartDate.ToString(TitleLabelFormat));
                }
                var start = CalendarStartDate;
                var beginOfMonth = false;
                var endOfMonth = false;
                for (int i = 0; i < buttons.Count; i++)
                {
                    endOfMonth |= beginOfMonth && start.Day == 1;
                    beginOfMonth |= start.Day == 1;
                    LstAttendanceDtl objAttendanceDtl = ListObjAttendanceTblList.Find(s => s.AttendanceDt.Equals(start.Date.ToString("dd/MM/yyyy")));
                    string remarks = string.Empty;
                    if (i < 7 && WeekdaysShow && changes.HasFlag(CalandarChanges.StartDay))
                    {
                        Device.BeginInvokeOnMainThread(() => labels[i].Text = start.ToString(WeekdaysFormat));
                        //labels[i].Text = start.ToString(WeekdaysFormat);
                        //DateTime d = Convert.ToDateTime(objAttendanceDtl.AttendanceDt).Date; 
                    }
                    if (changes.HasFlag(CalandarChanges.All))
                    {
                        Device.BeginInvokeOnMainThread(()=>buttons[i].Text = string.Format("{0}", start.Day));
                        //buttons[i].Text = string.Format("{0}", start.Day);
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() => buttons[i].TextWithoutMeasure = string.Format("{0}", start.Day));
                    }
                    buttons[i].Date = start;
                    var isInsideMonth = beginOfMonth && !endOfMonth;
                    if (objAttendanceDtl != null)
                    {
                        remarks = objAttendanceDtl.Remark;
                        if ((remarks.ToLower()).Trim() == stringFullDay.ToLower().Trim())
                        {
                            SetButtonPresent(buttons[i], isInsideMonth);
                        }
                        else if (remarks.ToLower().Trim() == stringAbsent.ToLower().Trim())
                        {
                            SetButtonAbsent(buttons[i], isInsideMonth);
                        }
                        else if (remarks.ToLower().Trim() == stringWeekOff.ToLower().Trim())
                        {
                            SetButtonWeekendMood(buttons[i], isInsideMonth);
                        }
                        else if (remarks.ToLower().Trim() == stringHolidays.ToLower().Trim())
                        {
                            SetButtonHolidays(buttons[i], isInsideMonth);
                        }
                        else if (remarks.ToLower().Trim() == stringSecondhalfAbsent.ToLower().Trim() ||
                            remarks.ToLower().Trim() == stringFirsthalfAbsent.ToLower().Trim())
                        {
                            SetButtonHalfDayMood(buttons[i], isInsideMonth);
                        }
                        else
                        {
                            SetButtonDisabled(buttons[i]);
                        }
                    }
                    else
                    {
                        SetButtonOutSideMonth(buttons[i]);
                    }
                    SpecialDate sd = null;
                    if (SpecialDates != null)
                    {
                        sd = SpecialDates.FirstOrDefault(s => s.Date.Date == start.Date);
                    }
                    if (sd != null)
                    {
                        SetButtonSpecial(buttons[i], sd);
                    }
                    else if (SelectedDate.HasValue && start.Date == SelectedDate.Value.Date)
                    {
                        SetButtonSelected(buttons[i], isInsideMonth);
                    }
                    start = start.AddDays(1);
                }
            }
            catch (Exception e)
            {
            }
        }
