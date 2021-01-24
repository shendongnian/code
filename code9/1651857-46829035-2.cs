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
        var SteamDetails= JsonConvert.DeserializeObject<dynamic>(SteamDetailsJson);
        avatar = SteamDetails.response.players[1].avatar.ToString();
        personaname = SteamDetails.response.players[1].personaname.ToString();
    }
