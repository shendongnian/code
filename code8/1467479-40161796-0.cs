        public class CP_VIP_Preview_TimeSlots
        {
            public int id { get; set; }
            [DisplayName("Time Slots")]
            public string timeSlot { get; set; }
            [DisplayName("Date Slots")]
            public string dateSlot { get; set; }
            public string combinedString
            {
                get
                {
                    return timeSlot + " " + dateSlot;
                }
            }
        }
