    using System;
    using Google.Apis.Calendar.v3;
    using GoogleSamplecSharpSample.Calendarv3.Auth;
    using Google.Apis.Calendar.v3.Data;
    
    namespace CalendarServerToServerApi
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            // create event which you want to set using service account authentication 
            Event myEvent = new Event
            {
                Summary = "Visa Counselling",
                Location = "Gurgaon sector 57",
                Start = new EventDateTime()
                {
                    DateTime = new DateTime(2017, 10, 4, 2, 0, 0),
                    TimeZone = "(GMT+05:30) India Standard Time"
                },
                End = new EventDateTime()
                {
                    DateTime = new DateTime(2017, 10, 4, 2, 30, 0),
                    TimeZone = "(GMT+05:30) India Standard Time"
                }
                //,
                // Recurrence = new String[] {
                //"RRULE:FREQ=WEEKLY;BYDAY=MO"
                //}
                //,
                // Attendees = new List<EventAttendee>()
                // {
                // new EventAttendee() { Email = "Srivastava998@gmail.com" }
                //}
            };
    
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
    
            public void Authenticate(object o, EventArgs e)
            {
                string[] scopes = new string[] {
         CalendarService.Scope.Calendar //, // Manage your calendars
     	//CalendarService.Scope.CalendarReadonly // View your Calendars
     };
                string cal_user = "calenderID@gamil.com"; //your CalendarID On which you want to put events
                //you get your calender id "https://calendar.google.com/calendar"
                //go to setting >>calenders tab >> select calendar >>Under calender Detailes at Calendar Address:
    
                string filePath = Server.MapPath("~/Key/key.json");
                var service = ServiceAccountExample.AuthenticateServiceAccount("xyz@projectName.iam.gserviceaccount.com", filePath, scopes);
                //"xyz@projectName.iam.gserviceaccount.com" this is your service account email id replace with your service account emailID you got it .
                //when you create service account https://console.developers.google.com/projectselector/iam-admin/serviceaccounts
    
                insert(service, cal_user, myEvent);
    
            }
    
    
    
            public static Event insert(CalendarService service, string id, Event myEvent)
            {
                try
                {
                    return service.Events.Insert(myEvent, id).Execute();
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
    
    
        }
    }
