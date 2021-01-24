    webBrowser.DocumentCompleted += (o, e) =>
    {
        var frame1 = webBrowser.Document.Body.GetElementsByClassName("frame-1");
        if (frame1.Count > 0)
        {
            var rows = frame1[0].GetElementsByClassName("row no-margin");
            if (rows.Count > 4)
            {
                var usernameForm = rows[4].GetElementsByClassName("form-control");
                if (rows.Count > 0)
                {
                    // Do something with value here
                    Console.WriteLine(usernameForm[0].GetAttribute("value"));
                }
            }
        }
    };
    webBrowser.Navigate("http://www.fakepersongenerator.com/Index/generate");
