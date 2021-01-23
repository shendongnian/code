    private async void buttonTestJSFCHI_Click(object sender, RoutedEventArgs e)
    {
        JSON_Worker w = new JSON_Worker();
        List<string> results = await w.StartTask("FileInfo", "https://us.api.battle.net/wow/auction/data/medivh?locale=en_US&apikey=<guid>");
        foreach (string res in results)
        {
            textBoxResults.Text += res;
        }
    }
    public async Task<List<string>> StartTask(string TaskName, string optionalUri= "no_uri_passed")
    {
        if (TaskName == "FileInfo")
        {
            //Need to use a lamba expression to call a delegate with a parameter
            if (!(optionalUri == "no_uri_passed"))
            {
                Task t = new Task(() => GetWowAuctionFileInfo(optionalUri));
                t.Start();
                return await t;
                //Func<string> function = new Func<string>(() => GetWowAuctionFileInfo(optionalUri));
                //Task<string> tInfo = Task<string>.Factory.StartNew(() => GetWowAuctionFileInfo(optionalUri));
            }
        }
    }
