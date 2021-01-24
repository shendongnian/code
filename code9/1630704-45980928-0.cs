    private IEnumerable<string> GetHTMLDownloadLinks(string url, char SplitChhar, string serach, int index)
    {
        //Initiates a new instance of WEbClient class
        List<string> links = new List<string>();
        WebClient WC = new WebClient();
        try
        {
            //Initiates a new stream instance with a url
            Stream stream = WC.OpenRead(url);
            //Initiates a streamreader to read the url parsed 
            StreamReader reader = new StreamReader(stream);
            string line;
            //Loops through the specifed url's html source 
            //and read every line
            while ((line = reader.ReadLine()) != null)
            {
                //If it finds the specified character that the user passed
                if (line.IndexOf(serach) != -1)
                {
                    //it adds it to the parts variable 
                    string[] parts = line.Split(SplitChhar);
                    //Returns the index of the found 
                    links.Add(parts[index]);
                }
            }
        }
        catch (Exception Ex)
        {
            MessageBox.Show($"There seems to be a problem: {Ex}", "I am an error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
        }
        links.Add("" + "\n");
        return links;
    }
----------
    var links = GetHTMLDownloadLinks(@"Link to the HTML file", '"', "download", 1);
    foreach (var link in links)
        TxtBox_WebInfo.Text += link + Environment.NewLine;
