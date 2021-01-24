    void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        WebBrowser browser = (WebBrowser)sender;
    
        HtmlElement expandDetails = browser.Document.GetElementById("form:SummarySubView:closedToggleControl");
        //When open ID for element is "form:SummarySubView:openToggleControl"
    
        if(expandDetails == null) //If already expanded
        {
            //Stuff
        }
        else
        {
            expandDetails.InvokeMember("click"); //Click on element to run AJAX
            while (expandDetails != null)
            {
                expandDetails = browser.Document.GetElementById("form:SummarySubView0:closedToggleControl");
                        
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
            }
            //Stuff
        }
    }
