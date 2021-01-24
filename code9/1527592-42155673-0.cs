    using System.IO;
    using System;
    using System.Xml;
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            string s = "<DataItem type=\"System.PropertyBagData\" time=\"2017-02-03T09:50:29.1118296Z\" sourceHealthServiceId=\"64ced8f3-385a-238c-eea4-008bab8ba249\"><Property Name=\"LoggingComputer\" VariantType=\"8\">g2aaS03OsX/9e5SSikdrVjFb4tkwhVUWeGh6pOv8nJ0=</Property><Property Name=\"EventDisplayNumber\" VariantType=\"8\">4502</Property><Property Name=\"ManagementGroupName\" VariantType=\"8\">/FTyfF2bs7hBhlQMJfSABYkkuTU98A80WiXu9TlL98w=</Property><Property Name=\"RuleName\" VariantType=\"8\">CollectNetMonInformation</Property><Property Name=\"ModuleTypeName\" VariantType=\"8\">Microsoft.EnterpriseManagement.Mom.Modules.NetmonDataSource.NetmonDataSource</Property><Property Name=\"StackTrace\" VariantType=\"8\">System.Exception: [2/3/2017 9:50:29 AM][InitializeDataReceiver]Exception while trying to connect to the agent :Could not open pipe, CreateFile Error : 2 WaitNamedPipe Error : 2 Pipe guid is : d0c4c51e-543b-4f25-8453-40000066967d</Property></DataItem>";
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(s);
            XmlNodeList xnList = xml.SelectNodes("/DataItem/Property");
            foreach (XmlNode xn in xnList)
            {
                string firstName = xn.InnerText;
                Console.WriteLine(firstName);
            }
        }
    }
