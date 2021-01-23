        class Program
        {
            static void Main(string[] args)
            {
                const string xml = @"<LIVE deviceid=""1394602"" utc=""18-Oct-2016 01:22:28"" local=""18-Oct-2016 12:22:28"">
           <READINGS type=""full"" probecount=""1"" portcount=""2"" discovery=""2"">
              <READING parameter=""Temperature"" shortparameter=""Temp"" unit=""°C"" channel=""1"" probeid=""3"" state=""OK"" probename=""EC202"" sensor=""0"">**22.9**   
              </READING>
           </READINGS>
    </LIVE>";
                var serializer = new XmlSerializer(typeof(LIVE));
                using(var reader = new StringReader(xml))
                {
                    var live = (LIVE)serializer.Deserialize(reader);
                    var output = default(double);
                    var text = Regex.Match(live.READINGS.READING.Text, @"\d+(\.\d+)?").Value;
                    if (double.TryParse(text, out output))
                    {
                        Console.WriteLine(output);
                    }
                }
                Console.ReadLine();
            }
    
        }
    
    
        [XmlRoot(ElementName = "READING")]
        class READING
        {
            [XmlAttribute(AttributeName = "parameter")]
            public string Parameter { get; set; }
            [XmlAttribute(AttributeName = "shortparameter")]
            public string Shortparameter { get; set; }
            [XmlAttribute(AttributeName = "unit")]
            public string Unit { get; set; }
            [XmlAttribute(AttributeName = "channel")]
            public string Channel { get; set; }
            [XmlAttribute(AttributeName = "probeid")]
            public string Probeid { get; set; }
            [XmlAttribute(AttributeName = "state")]
            public string State { get; set; }
            [XmlAttribute(AttributeName = "probename")]
            public string Probename { get; set; }
            [XmlAttribute(AttributeName = "sensor")]
            public string Sensor { get; set; }
            [XmlText]
            public string Text { get; set; }
        }
    
        [XmlRoot(ElementName = "READINGS")]
        class READINGS
        {
            [XmlElement(ElementName = "READING")]
            public READING READING { get; set; }
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "probecount")]
            public string Probecount { get; set; }
            [XmlAttribute(AttributeName = "portcount")]
            public string Portcount { get; set; }
            [XmlAttribute(AttributeName = "discovery")]
            public string Discovery { get; set; }
        }
    
        [XmlRoot(ElementName = "LIVE")]
        class LIVE
        {
            [XmlElement(ElementName = "READINGS")]
            public READINGS READINGS { get; set; }
            [XmlAttribute(AttributeName = "deviceid")]
            public string Deviceid { get; set; }
            [XmlAttribute(AttributeName = "utc")]
            public string Utc { get; set; }
            [XmlAttribute(AttributeName = "local")]
            public string Local { get; set; }
        }
