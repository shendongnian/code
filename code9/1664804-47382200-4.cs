    public struct UnitObject
    {
        public float V { get; private set; }
        public string T { get; private set; }
        public string D { get; private set; }
        public UnitObject(float v, string t, string d)
        {
            V = v;
            T = t;
            D = d;
        }
    }
