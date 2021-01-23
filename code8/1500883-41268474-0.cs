    public class StopRecord
    {
        [Serializable()]
        [System.Xml.Serialization.XmlRoot("root")]
        public class Root
        {
            public class stop
            {
                public stop(){}
                [System.Xml.Serialization.XmlAttribute("recordingid")]
                public string recordingid {get;set;}
                [System.Xml.Serialization.XmlAttribute("result")]
                public string result {get;set;}
            }
        }
    }
