        internal class Program
        {
            private static string txt = @"
    <PersonDetails><PersonTitle>Teacher</PersonTitle><Keystage3><Subject>
    <subjectName>maths</subjectName><subjectId>qq1</subjectId><subjectvalue>20</subjectvalue>
    <subjectscore /></Subject><Subject><subjectName>science</subjectName>
    <subjectId>sla1s</subjectId><subjectvalue>25</subjectvalue><subjectscore />
    </Subject></Keystage3><Keystage4><Subject><subjectName>ICT</subjectName>
    <subjectId>a1</subjectId><subjectvalue>10</subjectvalue><subjectscore />
    </Subject></Keystage4></PersonDetails>";
    
            static void Main()
            {
                XElement root = XElement.Parse(txt); // Load -> Parse
                var subjects = from stage in root.Descendants()
                               where stage.Name.LocalName == "Keystage3"
                               from subject in stage.Descendants()
                               where subject.Name.LocalName.Contains("Subject")
                               select new
                               {
                                   subname = subject.Element("subjectName").Value,
                                   subid = subject.Element("subjectId").Value,
                                   subvalue = subject.Element("subjectvalue").Value
                               };
    
                foreach (var subject in subjects) 
                    Console.WriteLine(subject); 
    
                Console.ReadLine();
            }
        }
