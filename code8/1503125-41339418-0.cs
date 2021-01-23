    using System.Net;
    
    string xyzstring;
    try
    {
        WebClient wc = new WebClient();
        xyzstring= wc.DownloadString("http://www.example.com/somefile.xml");
    }
    catch (WebException ex)
    {
       
        MessageBox.Show(ex.ToString());
    }
