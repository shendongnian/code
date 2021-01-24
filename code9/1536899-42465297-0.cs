    public MainClass
    {
        private class sharedClass
        {
           internal string sb1A { get; set; }
        }
        public class subClass1
        {
            private readonly sharedClass _shared;
            internal subClass1(sharedClass shared)
            {
                this._shared = shared;
            } 
            public string sb1A
            {
                get
                {
                   return this._shared.sb1A;
                }
                set
                {
                    this._shared.sb1A = value;
                }
            public string sb1B{get;set;}
        }
        public class subClass2
        {
            private readonly sharedClass _shared;
            public subClass2(shared s) 
            { 
                _shared = s;
            }
            public string sb2A{get;set;}
            public string sb2B{get;set;}
            public string wantPassString {get{return "I've got value " + _shared.sb1;}}
        }
        private readonly sharedClass _shared = new sharedClass();
        private readonly subClass1 _subClass1;
        private readonly subClass2 _subClass2;
        
        public MainClass() 
        {
            this._subClass1 = new subClass1(this._shared);
            this._subClass2 = new subClass2(this._shared);
        }
    }
