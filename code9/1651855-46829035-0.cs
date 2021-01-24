    private void GetSteamDetails()
    {
        var TempDet = JsonConvert.DeserializeObject<dynamic>(SteamDetailsJson);
        var TempJson = TempDet.response.players.ToString();
        TempJson = TempJson.Substring(1);
        TempJson = TempJson.Remove(TempJson.Length - 1);
        TempDet = JsonConvert.DeserializeObject<dynamic>(TempJson);
        details.SteamID = TempDet.steamid;
        details.SteamName = TempDet.personaname;
        details.RealName = TempDet.realname;
        details.Avatar = TempDet.avatar;
        details.AvatarMed = TempDet.avatarmedium;
        details.AvatarFull = TempDet.avatarfull;
    }
