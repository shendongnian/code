    public class Key : IEquatable<Key>
    {
        string Param1 {get;set;}
        string Param2 {get;set;}
        int Param3 {get;set;}
         public override int GetHashCode()
        {
            return Param1.GetHashCode();  //or something with all three
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
