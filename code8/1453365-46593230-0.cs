    protected class SagePayResponse
		{
			/// <summary>
			/// Raw xml response object
			/// </summary>
			private XmlDocument m_responseXml;
			/// <summary>
			/// Create a new response object from the xml string
			/// </summary>
			/// <param name="responseXml"></param>
			public SagePayResponse(string responseXml)
			{
				// create our xml doc
				m_responseXml = new XmlDocument();
				m_responseXml.LoadXml(responseXml);
				// find an error node
				XmlNode node = m_responseXml.SelectSingleNode("//vspaccess/errorcode");
				int errorCode = 0;
				if (node != null && int.TryParse(node.InnerText, out errorCode) == true && errorCode != 0)
				{
					// there was an error and we have a non-zero error code
					ErrorCode = errorCode;
				}
				// pick out any error description
				node = m_responseXml.SelectSingleNode("//vspaccess/error");
				if (node != null && node.InnerText.Length != 0)
				{
					ErrorText = node.InnerText;
				}
				// pick out the timestamp
				node = m_responseXml.SelectSingleNode("//vspaccess/timestamp");
				if (node != null && node.InnerText.Length != 0)
				{
					DateTime dt;
					if (DateTime.TryParseExact(node.InnerText, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt) == true)
					{
						Timestamp = DateTime.SpecifyKind(dt, DateTimeKind.Utc).ToLocalTime();
					}
				}
			}
