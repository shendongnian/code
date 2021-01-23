     class Program
        {
            public const string json = @"{""AppointmentList"":[{""AppointmentList"":{""id"":""1"",""MeetingId"":""1"",""MeetingName"":""Test Meeting 1"",""Length"":""90"",""Room"":""B2C"",""DateTimeFrom"":""1st Sept 2016"",""Venue"":""The old pub"",""DateCreated"":""2016-08-30 00:00:00"",""DateDue"":""2016-09-01 00:00:00"",""UserId"":""JohnsonPa""}},{""AppointmentList"":{""id"":""2"",""MeetingId"":""2"",""MeetingName"":""Test Meeting 2"",""Length"":""60"",""Room"":""B2C"",""DateTimeFrom"":""11th Sept 2016"",""Venue"":""The old pub"",""DateCreated"":""2016-09-01 00:00:00"",""DateDue"":""2016-09-12 00:00:00"",""UserId"":""JohnsonPa""}}]}";
    
            static void Main(string[] args)
            {
                var items = Newtonsoft.Json.JsonConvert.DeserializeObject<AppointmentItemList<Meeting1>>(json).GetList();
    
                var items2 = Newtonsoft.Json.JsonConvert.DeserializeObject<AppointmentItemList<Meeting2>>(json).GetList();
    
                Console.ReadLine();
            }
    
            public class AppointmentItemList<T> 
            {
                public List<AppointmentItem> AppointmentList { get; set; }
    
                public class AppointmentItem 
                {
                    public T AppointmentList { get; set; }
                }
    
                public IList<T> GetList()
                {
                    return AppointmentList.Select(al => al.AppointmentList).ToList();
                }
            }
    
            public class Meeting1 
            {
                [Newtonsoft.Json.JsonProperty("id")]
                public string Id { get; set; }
    
                public string MeetingName { get; set; }
            }
    
            public class Meeting2
            {
                [Newtonsoft.Json.JsonProperty("id")]
                public string Id { get; set; }
    
                public string Room { get; set; }
            }
        }
