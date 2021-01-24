    public class MatchResults
    {
        public string MatchAdmin { get; set; }
        public string Error { get; set; }
        public int allotHome { get; set; }
        public int allotAway { get; set; }
        public bool StrikeOut { get; set; }
        public int StrikeOutNbrOfRounds { get; set; }
        public int homeTeamId { get; set; }
        public int awayTeamId { get; set; }
        public int MatchId { get; set; }
        public bool Hcp { get; set; }
        public bool HcpBrutto { get; set; }
        public bool Allot { get; set; }
        public bool Finished { get; set; }
        public int Lanes { get; set; }
        public string SchemeId { get; set; }
        public List<PlayerResult> HomePlayerResults { get; set; }
        public List<PlayerResult> AwayPlayerResults { get; set; }
        public List<SquadResult> HomeSquadResults { get; set; }
        public List<SquadResult> AwaySquadResults { get; set; }
    }
    public class PlayerResult
    {
        public string LicNbr { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string PlayerShortName { get; set; }
        public string NameAndLicNbr { get; set; }
        public int ShirtNo { get; set; }
        public int Hcp { get; set; }
        public List<RoundResult> RoundResults { get; set; }
    }
    public class RoundResult
    {
        public int Round { get; set; }
        public int Result { get; set; }
        public int Table { get; set; }
        public int Squad { get; set; }
        public int RoundNbr { get; set; }
    }
    
