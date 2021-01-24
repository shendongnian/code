      public class SpecialNumber
        {
            private double _theNumber; 
    
            public double TheNumber
            {
                get { return _theNumber; }
                set
                {
                    _theNumber = value * Math.PI;
                }
            }
        }
