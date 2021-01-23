    public class Player
    {
        public string Nationality {get;set;}
        public int Points {get;set;}
        public double otherProp {get;set;}
    
        //new field is added
        public string groupings {get;set;}
    }
    
    var groups = new List<Func<Player, string>>();
    groups.Add(x => x.Nationality);
    groups.Add(x => (x.Points > 0).ToString().ToLower());
    Players.ForEach(x =>
        groups.ForEach(y => x.groupings = x.groupings + (x.groupings == null ? "" : "|") + y(x))
    );
    var answer = Players.GroupBy(x => x.groupings).ToDictionary(x => x.Key, x => x.ToList());
