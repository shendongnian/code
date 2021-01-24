    using (var client = new WebClient())
    {
        client.BaseAddress = add;
        client.Headers[HttpRequestHeader.ContentType] = "application/pdf";
        client.Headers.Add(HttpRequestHeader.Authorization, "Basic ");
        JObject jobject = generateReportPDFRequest(report.ReportID);
        byte[] result = client.UploadData(
                            add, 
                            "POST", 
                            Encoding.UTF8.GetBytes(jobject.ToString()));
        retval = AddReportPDF(reportid, result);
    }
