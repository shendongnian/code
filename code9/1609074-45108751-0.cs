       using System.Xml;
        using System.Xml.Linq;
        using System.Xml.XPath;
        
    public static List<XmlNode> queryXPath(this IXPathNavigable source, String xPath, XmlNamespaceManager nsManager = null)
        {
        	XPathNavigator xNav = source.CreateNavigator();
        	if (nsManager == null) nsManager = new XmlNamespaceManager(xNav.NameTable);
        	List<XmlNode> output = new List<XmlNode>();
        	XPathExpression xExp = XPathExpression.Compile(xPath, nsManager);
        	XPathNodeIterator xIterator = xNav.Select(xExp);
        	while (xIterator.MoveNext())
        	{
        		XmlNode tmp = xIterator.Current.UnderlyingObject as XmlNode;
        
        		output.Add(tmp);
        	}
        	return output;
        }
