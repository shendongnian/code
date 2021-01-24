    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test1.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                JobPositionPostings postings = Load(INPUT_FILENAME);
                // modify posting here
                Save(OUTPUT_FILENAME, postings);
            }
            static JobPositionPostings Load(string filename)
            {
                StreamReader reader = new StreamReader(INPUT_FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(JobPositionPostings));
                JobPositionPostings postings =  (JobPositionPostings)serializer.Deserialize(reader);
                return postings;
            }
            static void Save(string filename, JobPositionPostings postings)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(JobPositionPostings));
                StreamWriter writer = new StreamWriter(filename);
                serializer.Serialize(writer, postings);
            }
        }
        [XmlRoot("JobPositionPostings")]
        public class JobPositionPostings
        {
            [XmlElement("JobPositionPosting")]
            public List<JobPositionPosting> jobPositionPostings { get; set; }
        }
        [XmlRoot("JobPositionPosting")]
        public class JobPositionPosting
        {
            [XmlElement("JobAction")]
            public string JobAction { get; set; }
            [XmlElement("JobType")]
            public string jobType { get; set; }
            [XmlElement("JobPositionPostingID")]
            public int jobPositionPostingID { get; set; }
            [XmlElement("HiringOrg")]
            public HiringOrg hiringOrg { get; set; }
            [XmlElement("JobDisplayOptions")]
            public JobDisplayOptions jobDisplayOptions { get; set; }
        }
        [XmlRoot("HiringOrg")]
        public class HiringOrg
        {
            [XmlElement("HiringOrgName")]
            public string hiringOrgName { get; set; }
            [XmlElement("Industry")]
            public Industry industry { get; set; }
            [XmlElement("Contact")]
            public Contact contact { get; set; }
        }
        [XmlRoot("Industry")]
        public class Industry
        {
            [XmlElement("SummaryText")]
            public string summaryText { get; set; }
            [XmlElement("Contact")]
            public string contact { get; set; }
        }
        [XmlRoot("Contact")]
        public class Contact
        {
           [XmlElement("PersonName")]
            public PersonName personName { get; set; }
        }
        [XmlRoot("PersonName")]
        public class PersonName
        {
            [XmlElement("FormattedName")]
            public string formattedName { get; set; }
        }
        [XmlRoot("JobDisplayOptions")]
        public class JobDisplayOptions
        {
            [XmlElement("MicrositeName")]
            public string micrositeName { get; set; }
            [XmlElement("TemplateName")]
            public string templateName { get; set; }
    }
    }
