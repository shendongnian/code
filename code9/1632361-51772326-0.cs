    	public class CustomIdSignedXml : SignedXml
	{
		private static readonly string[] idAttrs = new string[]
		{
		"_id",
		"_Id",
		"_ID"
		};
		public CustomIdSignedXml(XmlDocument doc) : base(doc)
		{
			return;
		}
		public override XmlElement GetIdElement(XmlDocument doc, string id)
		{
			XmlElement idElem = null;
			// check to see if it's a standard ID reference
			//XmlElement idElem = base.GetIdElement(doc, id);
			//if (idElem != null)
			//	return idElem;
			//I get the feeling this is horridly insecure
			XmlElement elementById1 = doc.GetElementById(id);
			if (elementById1 != null) return elementById1;
			// if not, search for custom ids
			foreach (string idAttr in idAttrs)
			{
				idElem = doc.SelectSingleNode("//*[@" + idAttr + "=\"" + id + "\"]") as XmlElement;
				if (idElem != null)
					break;
			}
			return idElem;
		}
	}
