    public class MarineWeaponUpgrade : IMarine
    {
        private IMarine marine;
    
        public MarineWeaponUpgrade(IMarine marine)
        {
            this.marine = marine;
        }
    
        public int Damage
        {
            get { return this.marine.Damage + 1; } // here
            set { this.marine.Damage = value; }
        }
    }
