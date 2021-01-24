    TimeSpan a = new TimeSpan(12, 00, 00);       // 12 hours (could be midday)
    TimeSpan b = new TimeSpan(13, 00, 00);       // 13 hours (could be 1 pm)
    TimeSpan r = b - a;                          // 1 hour (could be 1 am)
    TimeSpan rr = new TimeSpan(r.Ticks / 2);     // 30 minutes (could be 12:30 am)
    dateTimePicker.Value = DateTime.Now.Add(rr); // current date time plus 30 minutes
    
    // -- OR --
    dateTimePicker.Value = DateTime.Now.Date.Add(rr); // current date plus 30 minutes
                                                      // eg: 2017-08-29 00:30:00
