        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("message")]
        public string Message { get; set; }
        [XmlElement("payload")]
        public T Payload { get; set; }
