    public class Service
    {
        [XmlAttribute("__serviceType")]
        public string ServiceType { get; set; }
        [XmlIgnore]
        public Perform Perform { get; set; }
        [XmlIgnore]
        public List<InputData> InputData { get; set; }
        [XmlElement("__perform", Type = typeof(Perform))]
        [XmlElement("__inputData", Type = typeof(InputData))]
        public object[] XmlInputAndPerformance
        {
            get
            {
                var inputData = (InputData ?? Enumerable.Empty<InputData>()).Cast<object>();
                var performData = Perform == null ? Enumerable.Empty<object>() : new object[] { Perform };
                return inputData.Take(1)
                    .Concat(performData)
                    .Concat(inputData.Skip(1))
                    .ToArray();
            }
            set
            {
                if (value == null)
                    return;
                var newInputs = value.OfType<InputData>().ToList();
                var newPerform = value.OfType<Perform>().ToList();
                if (newInputs.Count + newPerform.Count != value.Length)
                    throw new ArgumentException("Unknown type.");
                if (newPerform.Count > 1)
                    throw new ArgumentException("Too many Perform objects.");
                if (newPerform.Count > 0)
                    Perform = newPerform[0];
                (InputData = InputData ?? new List<InputData>()).AddRange(newInputs);
            }
        }
        [XmlElement("__execute")]
        public Execute Execute { get; set; }
        [XmlElement("__requestData")]
        public RequestData RequestData { get; set; }
        public Service() { }
    }
