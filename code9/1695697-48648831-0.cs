    static List<GovermentData> _data = new List<GovermentData>();
    static string[] _all = File.ReadAllLines(@"Assets/Resources/" + PREFIXES_FILEPATH + ".txt");
    static string[] _nations = File.ReadAllLines(@"Assets/Resources/" + NAMES_FILEPATH + ".txt");
    public static void Initialize()
    {
        EconomicPolicy ep = EconomicPolicy.RadicalCollectivist;
        TechLevel tl = TechLevel.Ancient;
        //iterate all prefixes
        for (int i = 0; i < _all.Length; i++)
        {
            if (_all[i].Length <= 0)
                continue;
            if(_all[i].StartsWith("["))
            {
                string s = _all[i];
                //remove first [ and last ]
                s = s.Remove(0, 1);
                s = s.Remove(s.Length - 1, 1);
                //split on ][
                string[] r = s.Split(new string[] { "][" }, StringSplitOptions.None);
                ep = (EconomicPolicy)Enum.Parse(typeof(EconomicPolicy), r[0]);
                tl = (TechLevel)Enum.Parse(typeof(TechLevel), r[1]);
            }
            else
                _data.Add(new GovermentData(_all[i], ep, tl));
        }
    }
    public static string GetCivilisationName(EconomicPolicy ep, TechLevel t)
    {
        GovermentData[] gd = _data.FindAll(d => d.economicPolicy == ep && d.techLevel == t).ToArray();
        if(gd.Length >= 1)
            return gd[0].name + " of " + _nations[_random.Next(0, _nations.Length)];
        else
            return gd[_random.Next(0, gd.Length)].name + " of " + _nations[_random.Next(0, _nations.Length)];
    }
    public struct GovermentData
    {
        public readonly string name;
        public readonly EconomicPolicy economicPolicy;
        public readonly TechLevel techLevel;
        public GovermentData(string name, EconomicPolicy economicPolicy, TechLevel techLevel)
        {
            this.name = name;
            this.economicPolicy = economicPolicy;
            this.techLevel = techLevel;
        }
    }
