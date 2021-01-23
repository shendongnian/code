    public class Test {
            public int Number { get; set; }
            private string _Text;
            public string Text {
                get {
                    if(Number > 5) {
                        return _Text;
                    } else {
                        //DEFAULT value here. 
                        return null;
                    }                
                }
                set {
                    if(Number > 5) {
                        _Text = value;
                    } else {
                        //DEFAULT Value. 
                        _Text = null;
                    }
                }
            }
        }
