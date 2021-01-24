    public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
    {
        ...
        var songId = intent?.GetIntExtra("songId");
        switch (intent.Action)
        {
            case ActionPlay:
                Console.WriteLine($"Action Play {songId.GetValueOrDefault()}");
                break;
            ...
