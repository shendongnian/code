    private void RegisterNYCommand(); // This ';'
    {
         Commands.CreateCommand("YN")
            .Do(async (e) => 
            {
                int yesnoIndex = rand.Next(randomTexts.Length);
                string memeToPost = yesno[yesnoIndex];
                await e.Channel.SendMessage(memeToPost);
            });
    }
