    public class bot {
        public List<player> player { get; set; }
    }
....
                bot bot = new bot();
                bot.clan = JsonConvert.DeserializeObject<clan>(json.ToString());
                bot.player = new List<player>();
                //assign aliases
                 foreach (Memberlist member in bot.clan.memberList) {
                   player a = new player();
                   a.tag = member.tag;
                   bot.player.Add(a);
                }
