    var broadcast = new BroadcastBlock<string>(s => s);
    var consumer = new ActionBlock<string>(s => WriteCache(s));
    broadcast.LinkTo(consumer);
    // fire and forget
    private async void MainTextbox_TextChanged(object sender, TextChangedEventArgs e)
    {
        await broadcast.SendAsync(MainTextbox.Text);
    }
    // running continually in a thread without a loop
    private void WriteCache(string toWrite)
    {
        File.WriteAllText(cacheFilePath, toWrite);
    }
