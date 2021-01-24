     public async Task StartWebCrawl()
        {
            
            var url = "http://challonge.com/jex0ymd2/standings";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var participants = new List<Particpants>();
            ObservableCollection<String> listStandings = new ObservableCollection<string>();
         
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                
                Task.Factory.StartNew(async () =>
                {
                    // Do the actual request and wait for it to finish.
                    await httpClient.GetStringAsync(url);
                
                    // Switch back to the UI thread to update the UI
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        // Update the UI
                        var divs = htmlDocument.DocumentNode.Descendants("td")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Equals("left display_name"))
                        .ToList();
                        foreach (var div in divs)
                        {
                            var participant = new Particpants
                            {
                                TeamName = div.Descendants("span").FirstOrDefault().InnerText
                            };
                            participants.Add(participant);
                        }
                        foreach (var name in participants)
                        {
                            listStandings.Add(name.TeamName);
                        }
                        ListView.ItemsSource = listStandings;
                        // Now repeat by scheduling a new request
                        StartWebCrawl();
                    });
                });
                // Don't repeat the timer (we will start a new timer when the request is finished)
                return false;
            });
        }
