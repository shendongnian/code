    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
          string result = System.Net.WebClient.DownloadString("http://www.example.com/api/TestMethod");
        }
        catch (System.Net.WebException ex)
        {
          //do something here to make the site unusable, e.g:
          myContent.Visible = false;
          myErrorDiv.Visible = true;
        }
    }
