    //Marked the method as async
    private async Task GetPopularSongsAsync()
    {
        //Now we can await the async method
        var html = await WebManager.GetPageAsync("http://myzuka.me/");
        var document = new HtmlParser().Parse(html.Result);
        var titles = document.DocumentElement.QuerySelectorAll(".player-inline p a");
        var artists = document.DocumentElement.QuerySelectorAll(".player-inline .details");
        var ids = document.DocumentElement.QuerySelectorAll(".player-inline").Select(m => m.GetAttribute("id")).ToList();
        for (int i = 0; i <= ids.Length; i++)
        {
            var newSong = new Song()
            {
                Title = titles[i].InnerHtml,
                Artist = GetArtistsFromInstance(artists[i].QuerySelectorAll("a.strong")),
                Size = "12.3",
                Bitrate = 320,
                Length = 12.3,
                Id = Regex.Replace(ids[i], @"[^\d]", "").Trim()
            };
            //No need to run a task to add to the list, just add it
            NewSongs.Add(newSong);
        }
    }
