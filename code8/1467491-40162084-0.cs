    public class CustomObject
    {
        public string Id { get; set; }
        public string TimeSlot { get; set; }
        public string DateSlot { get; set; }
    }
    foreach (var x in dbTimeSlots.Data)
    {
        var customObject = new CustomObject
        {
            Id = x.id.ToString(),
            TimeSlot = x.timeSlot,
            DateSlot = x.dateSlot
        };
        
        newList.Add(customObject);
    }
