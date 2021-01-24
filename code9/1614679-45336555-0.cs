    public void Test(IEnumerable<int> configs){
        var ratings = await Task.WhenAll(configs.Select(x=>Rate(x)));
        // More work done once all Rate tasks are complete
        var test = ratings.Select(x=>....);
    }
