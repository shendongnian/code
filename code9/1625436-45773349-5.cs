    public class Player
    {
        public Player(dynamic obj)
        {
            Id = ChoUtility.CastTo<int>(obj.Id);
            Sea = ChoUtility.CastTo<int>(obj.Sea);
            First = obj.First;
            Last = obj.Last;
            Team = obj.Team;
            Coll = obj.Coll;
            Num = ChoUtility.CastTo<int>(obj.Num);
            Age = ChoUtility.CastTo<int>(obj.Age);
            Hgt = ChoUtility.CastTo<int>(obj.Hgt);
            Wgt = ChoUtility.CastTo<int>(obj.Wgt);
            Pos = obj.Pos;
            Flg = String.IsNullOrEmpty(obj.Flg) ? "None" : obj.Flg;
            Trait = String.IsNullOrEmpty(obj.Trait) ? "None" : obj.Trait;
            Attr = new PlayerAttr();
            Attr.Str = ChoUtility.CastTo<int>(obj.Attr_Str);
            Attr.Agi = ChoUtility.CastTo<int>(obj.Attr_Agi);
            Per = new PlayerPer();
            Per.Lea = ChoUtility.CastTo<int>(obj.Per_Lea);
            Per.Wor = ChoUtility.CastTo<int>(obj.Per_Wor);
            Skills = new PlayerSkills();
            Skills.WR = ChoUtility.CastTo<int>(obj.Skills_WR);
            Skills.TE = ChoUtility.CastTo<int>(obj.Skills_TE);
        }
        public int Id { get; set; }
        public int Sea { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Team { get; set; }
        public string Coll { get; set; }
        public int Num { get; set; }
        public int Age { get; set; }
        public int Hgt { get; set; }
        public int Wgt { get; set; }
        public string Pos { get; set; }
        public PlayerAttr Attr { get; set; }
        public PlayerPer Per { get; set; }
        public PlayerSkills Skills { get; set; }
        public string Flg { get; set; }
        public string Trait { get; set; }
    }  
