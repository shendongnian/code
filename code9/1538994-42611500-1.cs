    List<AttendeeInfo> attend = new List<AttendeeInfo>();
    foreach (AttendeeInfo inf in rooms)
         {
           attend.Clear();
           attend.Add(inf.SmtpAddress);
    
           AvailabilityOptions options = new AvailabilityOptions();
           options.MaximumSuggestionsPerDay = 48;
           // service is ExchangeService object contains your authentication with exchange server
           GetUserAvailabilityResults results = service.GetUserAvailability(attend, new TimeWindow(DateTime.Now, DateTime.Now.AddDays(2)), AvailabilityData.FreeBusyAndSuggestions, options);
    
            foreach (AttendeeAvailability attendeeAvailability in results.AttendeesAvailability)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        if (attendeeAvailability.ErrorCode == ServiceError.NoError)
                        {
                            foreach (Microsoft.Exchange.WebServices.Data.CalendarEvent calendarEvent in
                            attendeeAvailability.CalendarEvents)
                            {
                                Console.WriteLine("Calendar event");
                                Console.WriteLine(" Starttime: " + calendarEvent.StartTime.ToString());
                                Console.WriteLine(" Endtime: " + calendarEvent.EndTime.ToString());
                                if (calendarEvent.Details != null)
                                {
                                    Console.WriteLine(" Subject:" + calendarEvent.Details.Subject);
    
                                }
                            }
                        }
                    }
                }
