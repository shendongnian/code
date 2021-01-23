    WebClient client = new WebClient();
    DateTime yesterday = DateTime.Today.AddDays(-1);
    DateTime tomorrow = DateTime.Today.AddDays(1);
    Uri ur = new Uri(http://remotehost.do/images/" + yesterday + "to" + tomorrow + "/excel.xls");
    client.Credentials = new NetworkCredential("username", "password");
    client.DownloadProgressChanged += WebClientDownloadProgressChanged;
    client.DownloadDataCompleted += WebClientDownloadCompleted;
    client.DownloadFileAsync(ur, @"C:\path\excel.xls");
