    using System.Net;
    using System.Xml;
    using System.Linq;
    
    public string xmlURL = "http://www.yr.no/place/sweden/stockholm/stockholm/forecast.xml";
    
    private void Form1_Load(object sender, EventArgs e) {
        string xmlResult = "";
    	using (WebClient c = new WebClient()) {
    		xmlResult = c.DownloadString(xmlURL);
    	}
    	// we have the web files contents in xmlResult now
    }
