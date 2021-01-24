    if (!System.DateTime.TryParse(playerData.timeStamp, out stamp)) {
        playerData.timeStamp = System.DateTime.UtcNow.ToString("o");
        stamp = System.DateTime.Parse(playerData.timeStamp);
    }
    stamp = stamp.ToUniversalTime();
