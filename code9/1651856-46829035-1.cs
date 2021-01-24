    Details details = new Details();
    public class Details
    {
        public string avatar { get; set; }
        public string avatarmedium { get; set; }
        public string avatarfull { get; set; }
        public string realname { get; set; }
        public string personaname { get; set; }
        public string steamid { get; set; }
    }
    private void GetSteamDetails()
    {
        var TempDet = JsonConvert.DeserializeObject<dynamic>(SteamDetailsJson);
        var TempJson = TempDet.response.players.ToString();
        TempJson = TempJson.Substring(1);
        TempJson = TempJson.Remove(TempJson.Length - 1);
        details = JsonConvert.DeserializeObject<Details>(TempJson);
    }
