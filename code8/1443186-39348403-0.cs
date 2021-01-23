	const string publishDatePartId = "publishDatePart";
	var publishDateXmlPart = wordDocument.MainDocumentPart.AddNewPart<CustomXmlPart>("application/xml", publishDatePartId);
	var writer = new XmlTextWriter(publishDateXmlPart.GetStream(FileMode.Create), System.Text.Encoding.UTF8);
	writer.WriteRaw($"<CoverPageProperties xmlns=\"http://schemas.microsoft.com/office/2006/coverPageProps\">" +
					$"<PublishDate>{DateTime.Today.ToShortDateString()}</PublishDate>" +
					$"</CoverPageProperties>");
	writer.Flush();
	writer.Close();
	var customXmlPropertiesPart = publishDateXmlPart.AddNewPart<CustomXmlPropertiesPart>(publishDatePartId);
	customXmlPropertiesPart.DataStoreItem = new DocumentFormat.OpenXml.CustomXmlDataProperties.DataStoreItem()
	{
		//I don't know what this ID is, but it seems to somehow relate to the Publish Date
		ItemId = "{55AF091B-3C7A-41E3-B477-F2FDAA23CFDA}"
	};
