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
                XElement companyFolders = (XElement)doc.FirstNode;
                new CompanyFolders(companyFolders);
            }
        }
        public class CompanyFolders
        {
            public static List<Company> companies = new List<Company>();
            public CompanyFolders(XElement companies)
            {
                CompanyFolders.companies = companies.Elements("company").Select(x => new Company(x)).ToList();
            }
            public class Company
            {
                string title { get; set; }
                public List<Department> departments = new List<Department>();
                public Company(XElement company)
                {
                    title = (string)company.Attribute("title");
                    departments = company.Descendants("department").Select(x => new Department(x)).ToList();
                }
                public class Department
                {
                    string title { get; set; }
                    public List<Folder> folders = new List<Folder>();
                    public Department(XElement department)
                    {
                        title = (string)department.Attribute("title");
                        folders = department.Element("folders").Elements("folder").Select(x => new Folder(x)).ToList();
                    }
                    public class Folder
                    {
                        string title { get; set; }
                        public List<Folder> folders = new List<Folder>();
                        public Folder(XElement folder)
                        {
                            title = (string)folder.Attribute("title");
                            if (folder.Element("folders") != null)
                            {
                                folders = folder.Element("folders").Elements("folder").Select(x => new Folder(x)).ToList();
                            }
                        }
                    }
                }
            }
        }
    }
