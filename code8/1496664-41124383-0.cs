    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication32
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Claims claims = new Claims()
                {
                    claims = doc.Descendants("Claim").Select(x => new ClaimsClaim()
                    {
                        claimID = (string)x.Element("ID"),
                        personID = (string)x.Element("Person").Element("ID"),
                        gender = (string)x.Element("Person").Element("Gender"),
                        encounterType = (int)x.Element("Encounter").Element("Type"),
                        codeTerm = (string)x.Element("Diagnosis").Element("CodeTerm"),
                        codeType = (string)x.Element("Diagnosis").Element("Type"),
                        code = (string)x.Element("Diagnosis").Element("Code"),
                        activityID = (string)x.Element("Activity").Element("ID"),
                        activityCodeTerm = (string)x.Element("Activity").Element("CodeTerm"),
                        start = (DateTime)x.Element("Activity").Element("Start"),
                        activityCode = (int)x.Element("Activity").Element("Code"),
                        quantity = (int)x.Element("Activity").Element("Quantity"),
                        clinician = (string)x.Element("Activity").Element("Clinician"),
                    }).ToList()
                };
            }
        }
        public class Claims
        {
            public List<ClaimsClaim> claims { get; set; }
        }
        public  class ClaimsClaim
        {
            public string claimID { get; set; }
            public string personID { get; set; }
            public string gender { get; set; }
            public int encounterType { get; set; }
            public string codeTerm { get; set; }
            public string codeType { get; set; }
            public string code { get; set; }
            public string activityID { get; set; }
            public string activityCodeTerm { get; set; }
            public DateTime start { get; set; }
            public int activityCode { get; set; }
            public int quantity { get; set; }
            public string clinician { get; set; }
        }
    }
