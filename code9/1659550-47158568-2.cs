    public class CMS
    {
        [XmlElement("Device")]
        List<Device> Devices {get;set;}
        //other properties here...
    }
    public class Device
    {
        public Port PortA { get;set;}
        public Port PortB { get;set;}
        public Port PortC { get;set;}
        public Port PortD { get;set;}
        public Port PortE { get;set;}
        //other properties here...TB, ParentConnectedToPort etc
    }
    public class Port
    {
        public Device Device { get; set; }
        //other properties here...Connected_BY etc
    }
