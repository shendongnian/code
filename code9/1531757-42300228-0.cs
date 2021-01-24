    using System;
    using System.Collections;
    namespace Game
    {
    public class Warrior:Inhabitant
    {
        private bool mobility;
        private bool immortality;
        public Warrior(string name,int age, bool mobility, bool immortality):base(name,age)
        {
            this.mobility=mobility;
            this.immortality=immortality;
        }
    }
}
