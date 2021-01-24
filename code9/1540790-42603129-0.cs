    var playedBanDataList = query.AsEnumerable()
        .Select(bannedPlayers => new PlayerBanData
        {
            Admin = bannedPlayers.Admin,
            BannedUntil = bannedPlayers.BannedUntil,
            IsPermanentBan = bannedPlayers.IsPermanentBan,
            PlayerName = bannedPlayers.PlayerName,
            Reason = bannedPlayers.Reason,
            IpAddresses = bannedPlayers.IpAddresses.Split(
                new [] {","}, 
                StringSplitOptions.RemoveEmptyEntries).ToList()
        });
