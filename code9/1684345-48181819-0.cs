    public abstract class DataObjectBase 
    {
       public virtual int ID { get; set; }
       // true if the entity is not saved yet:
       public virtual bool IsTransient { get { return ID <= 0; } }
       // alternatively, if ID is string:
       // public virtual string ID { get; set; }
       // public virtual bool IsTransient { get { return string.IsNullOrEmpty(ID); } }
        public override bool Equals(object obj)
        {
            var other = obj as DataObjectBase;
            if (other == null)
                return false;
            else if (IsTransient ^ other.IsTransient)
                return false;
            else if (IsTransient && other.IsTransient)
                return ReferenceEquals(this, other);
            else if (this.GetType() != other.GetType())
                return false;
            else return ID == other.ID;
        }
        private int? cachedHashCode; // this is used because hashcode shouldn't change
        public override int GetHashCode()
        {
            if (cachedHashCode.HasValue) return cachedHashCode.Value;
            cachedHashCode = IsTransient ? base.GetHashCode() : ID.GetHashCode();
            return cachedHashCode.Value;
        }
        public static bool operator ==(DataObjectBase x, DataObjectBase y)
        {
            return Object.Equals(x, y);
        }
       
        public static bool operator !=(DataObjectBase x, DataObjectBase y)
        {
            return !(x == y);
        }
    }
