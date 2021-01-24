        abstract class Person
        {
            public abstract string Hair { get; set; }
            public string getHairColor()
            {
                return this.Hair; // now it is accessible
            }
        }
        class Male : Person
        {
            private string _Hair;
            public override string Hair 
            { 
                get { return _Hair; } 
                set { _Hair = value }
            }
        }
