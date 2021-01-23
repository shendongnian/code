    public class Link : IEquatable<Link>
    {
        public Boolean linkFlag;
        public string Descriptor { get; set; }
        public string RecordId { get; set; }
        public bool Equals(Link other)
        {
            //Adjust for a suiting identifier and do all the sanity checks, if needed.
            return this.RecordId == other.RecordId;
        }
        public override int GetHashCode()
        {
            //You can also use another GetHash approach that suits you better.
            return this.RecordId.GetHashCode();
        }
    }
