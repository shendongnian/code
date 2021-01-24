    uri = new Uri(generatePdfsRetrieveUrl + pdfGuid + ".pdf");
    HttpClient client = new HttpClient();
    var response = await client.GetAsync(uri);
    using (var fs = new FileStream(
        HostingEnvironment.MapPath(string.Format("~/Downloads/{0}.pdf", pdfGuid)), 
        FileMode.CreateNew))
    {
        await response.Content.CopyToAsync(fs);
    }
