    using System;
    using Newtonsoft.Json;
					
    public class Program
    {
		public void Main()
    	{
			var json = @"{""data"":{""username"":""Rezoh"",""level"":305,""games"":{""quick"":{""wins"":""378""},""competitive"":{""wins"":""82"",""lost"":85,""played"":""167""}},""playtime"":{""quick"":""88 hours"",""competitive"":""36 hours""},""avatar"":""https://blzgdapipro-a.akamaihd.net/game/unlocks/0x0250000000000D70.png"",""competitive"":{""rank"":""3392"",""rank_img"":""https://blzgdapipro-a.akamaihd.net/game/rank-icons/season-2/rank-5.png""},""levelFrame"":""https://blzgdapipro-a.akamaihd.net/game/playerlevelrewards/0x025000000000092D_Border.png"",""star"":""https://blzgdapipro-a.akamaihd.net/game/playerlevelrewards/0x025000000000092D_Rank.png""}}";
			// read the doc: http://www.newtonsoft.com/json
			RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(json);
		
			Console.WriteLine(rootObject.data.username);
		}
        public class Quick
        {
            public string wins { get; set; }
        }
        public class Competitive
        {
            public string wins { get; set; }
            public int lost { get; set; }
            public string played { get; set; }
        }
        public class Games
        {
            public Quick quick { get; set; }
    		public Competitive competitive { get; set; }
		}
	
		public class Playtime
		{
    		public string quick { get; set; }
    		public string competitive { get; set; }
		}
		public class Competitive2
		{
    		public string rank { get; set; }
    		public string rank_img { get; set; }
		}
		public class Data
		{
    		public string username { get; set; }
    		public int level { get; set; }
    		public Games games { get; set; }
			public Playtime playtime { get; set; }
    		public string avatar { get; set; }
    		public Competitive2 competitive { get; set; }
    		public string levelFrame { get; set; }
    		public string star { get; set; }
		}
		public class RootObject
		{
    		public Data data { get; set; }
		}
	}
