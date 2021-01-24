    [DataContract]
    public class CompositeType
    {
        public bool _flag = true;
        public decimal? Value { get; set; }
        [DataMember(Name = "Value", EmitDefaultValue = false)]
        private decimal? ValueIfFlagTrue
        {
            get
            {
                return _flag ? Value : null;
            }
            set
            {
                _flag = value.HasValue ? true : false;
                Value = value;
            }
        }
    }
