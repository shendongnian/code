    [DataContract(Namespace = "Question46167039")]
    public class Configuration
    {
        public const string FileName = "Configuration.xml";
        public Configuration()
        {
            AList = new ListEmulator();
            AGuidList = new List<Guid>();
        }
        [DataMember]
        public List<Guid> AGuidList { get; set; }
        [DataMember(Name = "AList")]
        bool[] AlistArray
        {
            get
            {
                return AList == null ? null : AList.ToArray();
            }
            set
            {
                AList = new ListEmulator(value);
            }
        }
        [IgnoreDataMember] // Do not serialize this property directly
        public ListEmulator AList { get; set; }
    }
    public class ListEmulator
    {
        const bool IsPlannedDefault = false;  // Change to the appropriate values.
        const bool IsCompletedDefault = false;
        const bool IsRemainingDefault = false;
        const bool IsSerialDefault = false;
        public ListEmulator(IList<bool> list)
        {
            IsPlanned = list.ElementAtOrDefault(0, IsPlannedDefault);
            IsCompleted = list.ElementAtOrDefault(1, IsCompletedDefault);
            IsRemaining = list.ElementAtOrDefault(2, IsRemainingDefault);
            IsSerial = list.ElementAtOrDefault(3, IsSerialDefault);
        }
        public ListEmulator()
        {
            new ListEmulator(true, true, true, true);
        }
        public ListEmulator(bool item0, bool item1, bool item2, bool item3)
        {
            this.IsPlanned = item0;
            this.IsCompleted = item1;
            this.IsRemaining = item2;
            this.IsSerial = item3;
        }
        public bool IsPlanned { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsRemaining { get; set; }
        public bool IsSerial { get; set; }
        public bool[] ToArray()
        {
            return new[] { IsPlanned, IsCompleted, IsRemaining, IsSerial };
        }
    }
