        public class NoteDto
        {
            
            private string _project;
            public string Date { get; set; }
            public string Time { get; set; }
            public string Author { get; set; }
            public string NoteText { get; set; }
            [XmlIgnore]
            public string Project
            {
                get => _project;
                set => _project = value;
            }
        }
        [XmlRoot(ElementName = "NotesFor")]
        public class NotesForDto
        {
            [XmlAttribute(AttributeName="id")]
            public string ProjectID { get; set; }
            
            [XmlElement(ElementName ="Note")]            
            public List<NoteDto> NoteList { get; set; }
        }
        public static void Main(string[] args)
        {
            var notes = new NotesForDto
            {
                ProjectID = "SampelProject",
                NoteList = new List<NoteDto>
               {
                   new NoteDto
                   {
                       Author="Author1",
                       Date= "Date1",
                       NoteText="NoteText1",
                       Project="SampleProject",
                       Time="Time1"
                   },
                   new NoteDto
                   {
                       Author="Author2",
                       Date= "Date2",
                       NoteText="NoteText2",
                       Project="SampleProject",
                       Time="Time2"
                   }
               }
            };            
            XmlSerializer ser = new XmlSerializer(typeof(NotesForDto));
            using (var tw = File.Open("notes.xml",FileMode.Create))
            {
                ser.Serialize(tw,notes);
            }                
        }
