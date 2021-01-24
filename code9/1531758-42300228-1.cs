    using System;
    using System.Collections;
    namespace Game
    {
        public class Warrior:Inhabitant
        {
            // declare private fields
            private bool mobility;
            private bool immortality;
            public Warrior(string name,int age, bool mobility, bool immortality):base(name,age)
            {
                // initialize
                this.mobility=mobility;
                this.immortality=immortality;
            }
        }
    }
