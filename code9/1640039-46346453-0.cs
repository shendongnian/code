    var myDoc = new { id = "42", Name = "Max", City="Aberdeen" }; // this is the document you are trying to save
    var attachmentStream = File.OpenRead("c:/Path/To/File.pdf"); // this is the document stream you are attaching
    var client = await GetClientAsync();
    var createUrl = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);
    Document document = await client.CreateDocumentAsync(createUrl, myDoc);
    await client.CreateAttachmentAsync(document.SelfLink, attachmentStream, new MediaOptions()
        {
            ContentType = "application/pdf", // your application type
            Slug = "78", // this is actually attachment ID
        });
