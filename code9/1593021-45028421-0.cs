    public class TestClass
    {
        //Storing as string due to xsd validation as XsdDataContractExporter is 
        // using either xs:dataTime for DataTime or xs:duration for TimeSpan. xs:time is not used
        // And so xsd validation were failing for string in format 'HH:mm:ss' (despite DataContract can deserialize them as DateTime)
        [DataMember(Name = "Begin")]
        public string _beginString;
        [DataMember(Name = "End")]
        public string _endString;
        public TimeSpan Begin { get; private set; };
        public TimeSpan End{ get; private set; };
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            this.Begin = TimeSpan.Parse(_beginString);
            this.End = TimeSpan.Parse(_endString);
        }
    }
 
