    //using System.ComponentModel.DataAnnotations;
    public class SessionParameters
    {
        [Required]
        public string Rate { get; set; } = "";
        [Required]
        public string Culture { get; set; } = "En";
        [Required]
        public int HotelID { get; set; } = 0;
        public int SearchCriteria_NumberOfAdultsPerRoom { get; set; }
        public int SearchCriteria_NumberOfChildrenPerRoom { get; set; }
        public int SearchCriteria_NumberOfRooms { get; set; }
        public int MaximumNumberOfRooms { get; set; } = 4;
        public int MaximumNumberOfAdultsPerRoom { get; set; } = 4;
        public int MaximumNumberOfChildrenPerRoom { get; set; } = 3;
        public int MaximumDaysAheadBookable { get; set; } = 450;
        public int MaximumDaysBetweenCheckinCheckout { get; set; } = 31;
        // You may want to use a specific format for dates.
        public DateTime Checkin { get; set; } = DateTime.Today.Date;
        public DateTime Checkout { get; set; } = DateTime.Today.Date.AddDays(1);
    }
