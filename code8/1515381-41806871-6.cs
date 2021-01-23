    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Nullable<DateTime>> NullTest();
    }
    [DataContract]
    public class Nullable<T> where T : struct
    {
        public Nullable()
        {
        }
        internal T value;
        [DataMember]
        public bool HasValue { get; set; }
        [DataMember]
        public T Value
        {
            get
            {
                if (!this.HasValue)
                    throw new Exception("Property have  no value");
                return this.value;
            }
            set
            {
                this.value = value;
                this.HasValue = true;
            }
        }
        public Nullable(T value)
        {
            Value = value;
        }
        public T GetValueOrDefault()
        {
            return this.value;
        }
        public T GetValueOrDefault(T defaultValue)
        {
            if (!this.HasValue)
                return defaultValue;
            return this.value;
        }
        public override bool Equals(object other)
        {
            if (!this.HasValue)
                return other == null;
            if (other == null)
                return false;
            return this.value.Equals(other);
        }
        public override int GetHashCode()
        {
            if (!this.HasValue)
                return 0;
            return this.Value.GetHashCode();
        }
        public override string ToString()
        {
            if (!this.HasValue)
                return "";
            return this.Value.ToString();
        }
    }
