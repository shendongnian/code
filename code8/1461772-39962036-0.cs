    This sample will give the your desired json output,using a dictionary member      slotid will be the key
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    namespace jsonconversion
    {
    public class Program
    {
   
        public static void Main(string[] args)
        {
            Dictionary<int,MemberSlot> slots=new Dictionary<int, MemberSlot>();
            MemberSlot slot1 = new MemberSlot() {Id = 1, Holes =2, MemberId =     1};
            slots.Add(1,slot1);
            MemberBookingRequest mbr = new MemberBookingRequest
            {
                Booking = new MemberBooking()
                    {CourseId = 1, TeeDate ="",TeeTime = "",Slots = slots}
            };
            string jd = JsonConvert.SerializeObject(mbr);
            Console.WriteLine(jd);
        }
    }
    public class MemberBookingRequest
    {
        [JsonProperty("member_booking_request")]
        public MemberBooking Booking { get; set; }
    }
    public class MemberBooking
    {
        [JsonProperty("course_id")]
        public int CourseId { get; set; }
        [JsonProperty("date")]
        public string TeeDate { get; set; }
        [JsonProperty("time")]
        public string TeeTime { get; set; }
        [JsonProperty("slots")]
        public Dictionary<int, MemberSlot> Slots { get; set; }
    }
    public class MemberSlot
    {
        [JsonIgnore]
        public int Id { get; set; }
    
        [JsonProperty("holes")]
        public int Holes { get; set; }
        [JsonProperty("user_id")]
        public int MemberId { get; set; }
    }
}
