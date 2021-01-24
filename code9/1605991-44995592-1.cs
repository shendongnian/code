        abstract class Person
        {
            public abstract void SetHairColor(string hair);
            public abstract string Hair { get; }
            public string getHairColor()
            {
                return this.Hair; // now it is accessible
            }
        }
        class Male : Person
        {
            private string _Hair;
            public override string Hair { get { return _Hair; } }
            public override void SetHairColor(string hair)
            {
                this._Hair = hair;
            }
        }
