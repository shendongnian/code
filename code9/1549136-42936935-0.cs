    using Microsoft.SharePoint.Client.Search;
    using Microsoft.SharePoint.Client.Search.Query;
    string documentId = "SHAREPOINT-823645913-12";
    KeywordQuery kQry = new KeywordQuery(clientContext);
    kQry.QueryText = "DocId:" + documentId;
    SearchExecutor searchExec = new SearchExecutor(clientContext);
    ClientReuslt<ResultTableCollection> results = searchExec.ExecuteQuery(kQry);
    clientContext.ExecuteQuery();
    foreach(var result in results.Value[0].ResultRows)
    {
        //do stuff with result which contains the URL property for the document
        //along with any other crawled attribtues
    }
