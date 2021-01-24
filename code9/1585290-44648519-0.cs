    [Command("addOnList")]
    [Summary("Add a string to a list")]
    public async Task manageList(string csvList = null, [Remainder]string name = null)
    {
        var list = csvList.Split(',').ToList();
        //Code here
    }
