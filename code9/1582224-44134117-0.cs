    We can customize the schedule appointment by using AppointmentStyle Property of SFSchedule or AppointmentLoaded event in SFSchedule.
    
    We can change the font size of schedule appointment by setting through the TextStyle of AppointmentStyle property. Please find the below code example for above the same,
    
    Customizing through AppointmentLoaded event,
    
    void Schedule_AppointmentLoaded(object sender, AppointmentLoadedEventArgs e)
            {
                e.AppointmentStyle.TextStyle = UIFont.SystemFontOfSize(20);
            } 
    
    Customizing through AppointmentStyle property,
    
    SFAppointmentStyle appointmentstyle = new SFAppointmentStyle();
                appointmentstyle.TextStyle = UIFont.SystemFontOfSize(20);
                schedule.AppointmentStyle = appointmentstyle;
