    public class CreateFileViewModel
    {
        public int SelectedEnrolleId {set;get;}  // This new one
        public SelectList EnrolleeId { get; set; }
        public SelectList GroupId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public string Status { get; set; }
    }
