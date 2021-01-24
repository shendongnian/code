    [System.Serializable]
    public class Basic
    {
        public string name;
    }
    [System.Serializable]    
    public class Damage
    {
        public int stages;
        public int one;
        public int two;
        public int three;
    }
    [System.Serializable]
    public class Effect
    {
        public Damage damage;
    }
    
    [System.Serializable]
    public class RootObject
    {
        public Basic basic;
        public Effect effect;
    }
