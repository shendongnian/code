        public class Employee
        {
            static Employee[] Employees = null;
            const string FILENAME = @"c:\temp\test.xml";
            public static Boolean IsPostBack = false;
            string Employee_ID { get; set; }
            string First_Name { get; set; }
            string Last_Name { get; set; }
            string Classification_Group { get; set; }
            string Classification_Level { get; set; }
            string Postion_Number { get; set; }
            string English_Title { get; set; }
            string French_Title { get; set; }
            string Location { get; set; }
            string Language { get; set; }
            string Department_ID { get; set; }
            int Status { get; set; }
            int Type { get; set; }
            Boolean Displayed { get; set; }
            //protected void Page_Load(object sender, EventArgs e)
            public void Page_Load()
            {
                if (!IsPostBack)
                {
                    XDocument xdoc = XDocument.Load(FILENAME);
                    IEnumerable<XElement> emps = xdoc.Root.Descendants("employee");
                    Employees = emps.Select(x => new Employee()
                    {
                        Employee_ID = (string)x.Attribute("id"),
                        First_Name = (string)x.Element("First_Name"),
                        Last_Name = (string)x.Element("Last_Name"),
                        Classification_Group = (string)x.Element("Classification_Group"),
                        Classification_Level = (string)x.Element("Classification_Level"),
                        Postion_Number = (string)x.Element("Postion_Number"),
                        English_Title = (string)x.Element("English_Title"),
                        French_Title = (string)x.Element("French_Title"),
                        Location = (string)x.Element("Location"),
                        Language = (string)x.Element("Language"),
                        Department_ID = (string)x.Element("Department_ID"),
                        Status = (int)x.Element("Status"),
                        Type = (int)x.Element("Type"),
                        Displayed = false
                    }).ToArray();
                }
            }
        }
