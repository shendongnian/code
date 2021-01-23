        public IEnumerable<Microsoft.Exchange.WebServices.Data.Appointment> getAppointments(string userName, string userPwd)
        {
   
            DateTime startDate = DateTime.Now.AddYears(-1);
            DateTime endDate = startDate.AddYears(1);
            const int NUM_APPTS = 5;
            ExchangeService serviceExchange = ExchangeWebService.ConnectToService(userName, userPwd);
            // Initialize the calendar folder object with only the folder ID. 
            CalendarFolder calendar = CalendarFolder.Bind(serviceExchange, WellKnownFolderName.Calendar, new PropertySet());
            // Set the start and end time and number of appointments to retrieve.
            CalendarView cView = new CalendarView(startDate, endDate, NUM_APPTS);
            // Limit the properties returned to the appointment's subject, start time, and end time.
            cView.PropertySet = new PropertySet(AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.End);
            // Retrieve a collection of appointments by using the calendar view.
            FindItemsResults<Microsoft.Exchange.WebServices.Data.Appointment> appointments = calendar.FindAppointments(cView);
            return appointments;
        }
