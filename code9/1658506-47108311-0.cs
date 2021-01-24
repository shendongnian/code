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
                string selectedVSver = "";
                string path2SelectedVSVerProjects = "";
                Boolean path2VSoverridden = true;
                string path2PRCfile = "";
                string path2XMLfile = "";
                string path2VSProject = "";
                XDocument doc = new XDocument();
                XElement powerCOBOL2NETMigration = new XElement("PowerCOBOL2NETMigration", new object[] {
                    new XElement("config", new object[] {
                        new XElement("VSVersion", selectedVSver),
                        new XElement("path2SelectedVSVerProjects", path2SelectedVSVerProjects),
                        new XElement("path2VSoverridden", path2VSoverridden),
                        new XElement("path2PRCfile", path2PRCfile),
                        new XElement("path2XMLfile", path2XMLfile),
                        new XElement("path2VSProject", path2VSProject)
                    })
                });
                doc.Add(powerCOBOL2NETMigration);
                doc.Save(FILENAME);
            }
        }
    }
