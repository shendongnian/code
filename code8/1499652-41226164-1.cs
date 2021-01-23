    using System;
    using Newtonsoft.Json;
					
    public class Program
    {
		public void Main()
    	{
			var json = @"{""data"":{""username"":""Rezoh"",""level"":305,""games"":{""quick"":{""wins"":""378""},""competitive"":{""wins"":""82"",""lost"":85,""played"":""167""}},""playtime"":{""quick"":""88 hours"",""competitive"":""36 hours""},""avatar"":""https://blzgdapipro-a.akamaihd.net/game/unlocks/0x0250000000000D70.png"",""competitive"":{""rank"":""3392"",""rank_img"":""https://blzgdapipro-a.akamaihd.net/game/rank-icons/season-2/rank-5.png""},""levelFrame"":""https://blzgdapipro-a.akamaihd.net/game/playerlevelrewards/0x025000000000092D_Border.png"",""star"":""https://blzgdapipro-a.akamaihd.net/game/playerlevelrewards/0x025000000000092D_Rank.png""}}";
			// read the doc: http://www.newtonsoft.com/json
			var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
		
			Console.WriteLine(rootObject.data.username);
		}
        public class Quick
        {
            // Free case support!
            public string Wins { get; set; }
        }
        public class Competitive
        {
            public string Wins { get; set; }
            public int Lost { get; set; }
            public string Played { get; set; }
        }
        public class Games
        {
            public Quick Quick { get; set; }
    		public Competitive Competitive { get; set; }
		}
	
		public class Playtime
		{
    		public string Quick { get; set; }
    		public string Competitive { get; set; }
		}
		public class Competitive2
		{
    		public string Rank { get; set; }
    		// attribute ftw! http://www.newtonsoft.com/json/help/html/SerializationAttributes.htm
    		[JsonProperty(PropertyName = "rank_img")]
    		public string RankImg { get; set; }
		}
		public class Data
		{
    		public string Username { get; set; }
    		public int Level { get; set; }
    		public Games Games { get; set; }
			public Playtime Playtime { get; set; }
    		public string Avatar { get; set; }
    		public Competitive2 Competitive { get; set; }
    		public string LevelFrame { get; set; }
    		public string Star { get; set; }
		}
		public class RootObject
		{
    		public Data Data { get; set; }
		}
	}
