    var client = new WebClient();
    client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCompletedHandler);
            
    for (long i = 1; i < gethow; i++)
    {
        string WebAdress = "https://xxxxxx.xxx/web?id=";
        var request = WebAdress + (fromNumber - 1 + i);    
        
        client.DownloadStringAsync(request);
        
    }
    // -- > Elsewhere in your form
    void DownloadStringCompletedHandler(object sender, DownloadStringCompletedEventArgs e)
    {
        slas = "0" + Convert.ToString((fromNumber - 1 + i));
        if (result == "Test")
        {
            if (!listBox1.Items.Contains(slas))
            {                {
                 listBox1.Items.Add(slas);
                 godn++;
             }
        }
    }
