    public class Key : IEquatable<Key>
    {
        public Key(string p1, string p2, int p3)
        {
            Param1 = p1;
            Param2 = p2;
            Param3 = p3;
        }
        string Param1 {get;}
        string Param2 {get;}
        int Param3 {get;}
         public override int GetHashCode()
        {
            return Param1.GetHashCode();  //ideally something with all three parameters
        }
        public override bool Equals(object other)
        {
            return Equals(other as Key);
        }
        public bool Equals(Key other)
        {
            if (other == null) return false;
            return Param1 == obj.Param1 && Param2 == obj.Param2 && Param3 ==obj.Param3;
        }
    }
