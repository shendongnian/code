    public class point : GameData,  ICloneable
    {
        public int TouchGround;
    
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
