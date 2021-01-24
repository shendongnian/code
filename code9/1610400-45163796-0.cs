    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication67
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement exportJobs = doc.Root;
                XNamespace ns = exportJobs.GetDefaultNamespace();
                var results = exportJobs.Descendants(ns + "Job").Select(x => new {
                    id = (string)x.Attribute(ns + "Id"),
                    comment = (string)x.Element(ns + "Comments"),
                    dueDate = (DateTime)x.Element(ns + "DueDate"),
                    formattedDueDate = (DateTime)x.Element(ns + "FormattedDueDate"),
                    targetDueDate = (DateTime)x.Element(ns + "TargetDueDate"),
                    serviceTypeId = (int)x.Element(ns + "ServiceTypeId"),
                    serviceType = (string)x.Element(ns + "ServiceType"),
                    tenantName = (string)x.Element(ns + "TenantName"),
                    uprn = (string)x.Element(ns + "Uprn"),
                    houseName = (string)x.Element(ns + "HouseName")
                }).ToList();
            }
        }
    }
