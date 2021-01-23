    namespace StackOverflow
    {
		using System;
		using System.Xml;
		class XmlTest
		{
			public static void yourTest()
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load("yourXmlPath.xml");
				// It is recommended that you use the XmlNode.SelectNodes or XmlNode.SelectSingleNode method instead of the GetElementsByTagName method.
				XmlNodeList xmlNodes = xmlDocument.GetElementsByTagName("attribute");
				foreach(XmlNode xmlNode in xmlNodes)
				{
					if (xmlNode.ParentNode.Attributes.GetNamedItem("alias") != null)
					{
						string attributeName = xmlNode.ParentNode.Attributes.GetNamedItem("alias").InnerText + "." + xmlNode.GetNamedItem("name").InnerText;
						Console.WriteLine(attributeName);
					}
					else
					{
						string attributeName = xmlNode.Attributes.GetNamedItem("name").InnerText;
						Console.WriteLine(attributeName);
					}
				}
			}
		}
	}
