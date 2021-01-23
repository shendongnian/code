    public class Player
    {
        public string Nationality {get;set;}
        public int Points {get;set;}
        public double otherProp {get;set;}
    
        //new field is added
        public string groupings {get;set;}
    }
    
    var groups = new List<Func<MyType, string>>();
    groups.Add(x => (x.Points > 0).ToString().ToLower());
    Players.ForEach(x => {
        x.groupings = x.Nationality;
        groups.ForEach(y => x.groupings = x.groupings + "|" + y(x));
    });
    var answer = Players.GroupBy(x => x.groupings).ToDictionary(x => x.groupings, x.ToList());
