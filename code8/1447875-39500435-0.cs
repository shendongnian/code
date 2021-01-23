    <?xml version="1.0" encoding="UTF-8"?>
    <Report xmlns="ProfilpflegeStatus" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="ProfilpflegeStatus" xsi:schemaLocation="ProfilpflegeStatus http://bitreporting/ReportServer?%2FSkillscout%2FProfilpflegeStatusU+0026%3AFormat=XMLU+0026%3ASchema=True">
      <Tablix1>
        <Details_Collection>
          <Details Textbox15="Klaus Baumgärtner" Textbox5="Marketing Kommunikation" Textbox3="Mannheim" Textbox26="Nein" Textbox10="Mona" Textbox8="Aalfeld"/>
          <Details Textbox15="Marc Schmitt" Textbox5="Marc Schmitt" Textbox3="Mannheim" Textbox26="Nein" Textbox10="Frank" Textbox8="Abegg" Textbox14="2013-03-11T19:18:22.513" Textbox12="Service Management"/>
          <Details Textbox15="Marc Schmitt" Textbox5="Marc Schmitt" Textbox3="Mannheim" Textbox26="Ja" Textbox10="Frank" Textbox8="Abegg" Textbox14="2016-09-08T23:21:45" Textbox12="Standard" Textbox24="2016-09-08T23:21:45"/>
          <Details Textbox15="Marc Schmitt" Textbox5="Marc Schmitt" Textbox3="Mannheim" Textbox26="Nein" Textbox10="Frank" Textbox8="Abegg" Textbox14="2012-11-29T01:51:13.16" Textbox12="Testing"/>
          <Details Textbox15="Marc Schmitt" Textbox5="Marc Schmitt" Textbox3="Mannheim" Textbox26="Nein" Textbox10="Frank" Textbox8="Abegg" Textbox14="2013-05-14T22:50:08.53" Textbox12="Testmanagement"/>
        </Details_Collection>
      </Tablix1>
    </Report>
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement report = (XElement)doc.FirstNode;
                XNamespace ns = report.GetDefaultNamespace();
                List<LongProfile> result = doc.Descendants(ns + "Details").Select(x => new LongProfile() {
                    Firstname = (string)x.Attribute("Textbox10"),
                    Lastname = (string)x.Attribute("Textbox8"),
                    TeamLeader = (string)x.Attribute("Textbox5"),
                    Status = (string)x.Attribute("Textbox26"),
                    Date = x.Attribute("Textbox14") == null ? new DateTime() :(DateTime)x.Attribute("Textbox14")
                }).ToList();
            }
        }
        public class LongProfile
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string TeamLeader { get; set; }
            public string Status { get; set; }
            public DateTime  Date { get; set; }
        }
    }
