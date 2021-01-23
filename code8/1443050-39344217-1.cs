    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
          System.Net.WebClient client = new System.Net.WebClient();
          string result = client.DownloadString("http://www.example.com/api/TestMethod");
        }
        catch (System.Net.WebException ex)
        {
          //do something here to make the site unusable, e.g:
          myContent.Visible = false;
          myErrorDiv.Visible = true;
        }
    }
