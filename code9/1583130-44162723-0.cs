    string szJava = string.Empty;
    szJava = "a = $find(\"ctl00_WebSplitter1_tmpl1_ContentPlaceHolder1_dtePickerBegin\"); a.set_text(\"5/20/2017\");";
    object a = wb.Document.InvokeScript("eval", new object[] { szJava });
    if (webDatePicker != null)
        webDatePicker.InvokeMember("submit");
    HtmlElement button = wb.Document.GetElementById("ctl00$WebSplitter1$tmpl1$ContentPlaceHolder1$HeaderBTN1$btnRetrieve");
    if (button != null)
    {
         button.InvokeMember("click");
    }
 
