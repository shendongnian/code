    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
      BasicHttpBinding listsSoapBinding = new BasicHttpBinding();
      listsSoapBinding.Name = "ListsSoap";
      listsSoapBinding.Security.Mode = BasicHttpSecurityMode.Transport;
	  listsSoapBinding.Security.Transport.ClientCredentialType =
        HttpClientCredentialType.Ntlm;
      
      EndpointAddress listsSoapAddress = 
        new EndpointAddress(Variables.SharePointListServiceUrl); 
    
      ListsSoapClient listsSoapClient = 
        new ListsSoapClient(listsSoapBinding, listsSoapAddress);
      XmlElement attachmentCollection = listsSoapClient.GetAttachmentCollection(
        Variables.SharePointListGuid, Row.ID.ToString());
      foreach(XmlNode node in attachmentCollection.ChildNodes)
      {
	    using (WebClient client = new WebClient())
	    {
		  AttachmentsBuffer.AddRow();
		  CredentialCache credentialCache = new CredentialCache();
		  credentialCache.Add(
			  new Uri(Variables.SharePointUrl),
			  "NTLM",
			  new NetworkCredential(
                Variables.SharePointAccountUsername, 
                Variables.SharePointAccountPassword, 
                Variables.SharePointAccountDomain));
		  client.Credentials = credentialCache;
		  string attachmentUrl = node.InnerText;
		  byte[] data = client.DownloadData(attachmentUrl);
		  AttachmentsBuffer.AttachmentFile.AddBlobData(data);
		  AttachmentsBuffer.FileName = Path.GetFileName(node.InnerText);
		  AttachmentsBuffer.NewsArticleId = Row.NewsArticleId;
		  AttachmentsBuffer.UniqueID = Guid.NewGuid();
	    }
	  }
    }
