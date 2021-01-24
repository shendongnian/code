            public class ViewModel
    {
        public string OfferReviewId { get; set; }
        public string UserId { get; set; }
        public string Review { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get { return this.LastName + " , " + this.FirstName; } }
    }
