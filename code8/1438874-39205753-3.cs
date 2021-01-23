        public class RoundedXyzComparer : IEqualityComparer<XYZ>
        {
            public int RoundingDigits { get; set; }
            public RoundedXyzComparer(int roundingDigits)
            {
               RoundingDigits = roundingDigits;
            }
            public bool Equals(XYZ x, XYZ y)
            {
               return Math.Round(x.X, RoundingDigits, MidpointRounding.AwayFromZero) == Math.Round(y.X, RoundingDigits, MidpointRounding.AwayFromZero) && 
                      Math.Round(x.Y,RoundingDigits, MidpointRounding.AwayFromZero) == Math.Round(y.Y, RoundingDigits, MidpointRounding.AwayFromZero);
            }
            public int GetHashCode(XYZ obj)
            {
               return Math.Round(obj.X, RoundingDigits, MidpointRounding.AwayFromZero).GetHashCode() ^
                      Math.Round(obj.Y, RoundingDigits, MidpointRounding.AwayFromZero).GetHashCode();
            }
         }
         //Use:
         myList.Distinct(new RoundedXyzComparer(5));
