    public class OBJECT
    {
        public int ID { get; set; }
        public string someString { get; set; }
    
        public override bool Equals(object obj)
        {
            OBJECT q = obj as OBJECT;
            return q != null && q.ID == this.ID && q.someString == this.someString;
        }
    
        public override int GetHashCode()
        {
            return this.ID.GetHashCode() ^ this.someString.GetHashCode();
        }
    }
