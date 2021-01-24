            [XmlRoot]
            [Serializable]
            public class UserSetUp
            {
                [XmlElement]
                public TableA TableA { get; set; }
            }
    
            [Serializable]
            public class TableA
            {
                [XmlElement]
                public string revBegin { get; set; }
    
                [XmlElement]
                public string revEnd { get; set; }
            }
