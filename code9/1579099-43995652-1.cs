    public class clsAttendance : IEquatable<clsAttendance>
    {
        public string TagId { get; set; }
        public DateTime LastFoundDate { get; set; }
        public DateTime CapturedAt { get; set; }
        public override bool Equals(object obj)
        {
            var otherAttendance = obj as clsAttendance;
            if (otherAttendance == null)
            {
                return false;
            }
            return this.Equals(otherAttendance);
        }
        public override int GetHashCode()
        {
            return (this.TagId != null ? this.TagId.GetHashCode() : 0);
        }
        public bool Equals(clsAttendance other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(this.TagId, other.TagId);
        }
    }
