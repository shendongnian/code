    List docs = web.Lists.GetByTitle("DOCUMENTS");
    Microsoft.SharePoint.Client.File uploadFile = docs.RootFolder.Files.Add(newFile);
    clientContext.ExecuteQuery();
    
    clientContext.Load(uploadFile.ListItemAllFields, item => item["EncodedAbsUrl"]);
    clientContext.ExecuteQuery();
    
    var fileUrl = uploadFile.ListItemAllFields["EncodedAbsUrl"].ToString();
    
    string link = clientContext.Web.CreateAnonymousLinkForDocument(fileUrl, ExternalSharingDocumentOption.View);
    
    string linkwithExpiration = clientContext.Web.CreateAnonymousLinkWithExpirationForDocument(fileUrl, ExternalSharingDocumentOption.Edit, DateTime.Now.AddMonths(1));
    
    SharingResult result = clientContext.Web.ShareDocument(fileUrl, "someone@example.com", ExternalSharingDocumentOption.View, true, "Doc shared programmatically");
