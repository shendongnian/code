    [ItemCanBeNull]
    public async Task<string> GetSomeName() {
        var time = DateTime.Now;
        if(time.Second == 30) { 
            return "Jimmy"; 
        } else {
            return null;
        }
    }
