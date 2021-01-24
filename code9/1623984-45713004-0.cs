    // Insert XML to request body
	private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
	{
		using (var stringWriter = new StringWriter())
		using (var xmlTextWriter = XmlWriter.Create(stringWriter))
		using (Stream stream = webRequest.GetRequestStream())
		{
			// Get XML contents as string
			soapEnvelopeXml.WriteTo(xmlTextWriter);
			xmlTextWriter.Flush();
			string str = stringWriter.GetStringBuilder().ToString();
			// Remove all formatting
			str = str.Replace("\r", "");
			str = str.Replace("\n", "");
			while (str.IndexOf("  ") > -1)
			{
				str = str.Replace("  ", " ");
			}
			str = str.Replace("> <", "><");
			str = str.Replace("\" />", "\"/>");
			// Write the unbeutified text to the request stream
			MemoryStream ms = new MemoryStream(UTF8Encoding.Default.GetBytes(str));
			ms.WriteTo(stream);
		}
	}
