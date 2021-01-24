    public ActionResult DownloadPdf(int? id)
    {
    	var fullUrl = Url.Action("Details", "MyController", new { id }, Request.Url.Scheme);
    	var pdf = new HtmlToPdf();
    	string fileName = "Some name.pdf";
    	var cookies = Request.Cookies.AllKeys.ToDictionary(k => k, k => Request.Cookies[k].Value);
    	foreach(var cookie in cookies)
    	    pdf.HttpCookies.AddCookie(cookie.Key,cookie.Value);
    
    	return File(pdf.ConvertUrlToMemory(fullUrl), System.Net.Mime.MediaTypeNames.Application.Pdf, fileName);
    }
