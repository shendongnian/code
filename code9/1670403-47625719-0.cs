        public class UserProgramCode
        {
         static StringBuilder resultName = new StringBuilder();
         public static string GetNodeByName(string input1)
         {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(input1);
            }
            catch (XmlException xe)
            {
                Console.WriteLine("Input XML is not parseable. " + xe.Message);
            }
            string xpath = "Names/Name";
            var nodes = xmlDoc.SelectNodes(xpath);
            foreach (XmlNode childrenNode in nodes)
            {
                resultName.AppendLine(childrenNode.SelectSingleNode("FirstName").InnerText + " " + childrenNode.SelectSingleNode("LastName").InnerText);
            }
            return resultName.ToString();
         }
        }
