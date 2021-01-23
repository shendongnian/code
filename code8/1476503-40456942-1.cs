    var lastSentOn=DateTime.MinValue;
    commands.CreateCommand("Meme")
    .Do(async (e) =>
    {
        Console.WriteLine(time.ToString("h:mm:ss tt"));
        if((DateTime.Now - lastSentOn).TotalSeconds > 3))
        { 
            int RandomMeme = rng.Next(MemeList.Length);
            string memetopost = MemeList[RandomMeme];
            lastSentOn = DateTime.Now;
            await e.Channel.SendFile(memetopost);
        }
    });
