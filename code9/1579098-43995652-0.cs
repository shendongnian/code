    public class clsAttendance
    {
        public string TagId { get; set; }
        public DateTime LastFoundDate { get; set; }
        public DateTime CapturedAt { get; set; }
 
        public override bool Equals(object obj)
        {
            var item = obj as clsAttendance;
            if (item == null)
            {
                return false;
            }
           return string.Equals(this.TagId, item.TagId);
        }
    
        public override int GetHashCode()
        {
            return TagId?.GetHashCode() ?? int.MinValue;
        }
    }
