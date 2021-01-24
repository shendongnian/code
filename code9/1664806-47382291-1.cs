    public struct UnitObject 
    {
        public float    v;
        public string   t;
        public string   d;
        public UnitObject(float val, string s1, string s2)
        {
           v = val; t = s1; d = s2;
         }
    }
    
    public class UnitStandard
    {
        public UnitObject[] UnitDict = new UnitObject[] { new UnitObject( 1f, "s", "s" ) };
    } 
