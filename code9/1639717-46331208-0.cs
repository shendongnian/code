    Calendar basicCalendar = new Calendar();
    
    basicCalendar.DisplayDateStart = new DateTime(2009, 1, 10);
    basicCalendar.DisplayDateEnd = new DateTime(2009, 4, 18);
    basicCalendar.DisplayDate = new DateTime(2009, 3, 15);
    basicCalendar.SelectedDate = new DateTime(2009, 2, 15);
    
    //Adding your WPF control
    elementHost1.Child = basicCalendar;
