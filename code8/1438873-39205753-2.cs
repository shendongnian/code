        public class RoundedXyzComparer : IEqualityComparer<XYZ>
        {
            public int RoundingDigits { get; set; }
            public RoundedXyzComparer(int roundingDigits)
            {
               RoundingDigits = roundingDigits;
            }
            public bool Equals(XYZ x, XYZ y)
            {
               return Math.Round(x.X, RoundingDigits) == Math.Round(y.X, RoundingDigits) && 
                      Math.Round(x.Y,RoundingDigits) == Math.Round(y.Y, RoundingDigits);
            }
            public int GetHashCode(XYZ obj)
            {
               return Math.Round(obj.X, RoundingDigits).GetHashCode() ^
                      Math.Round(obj.Y, RoundingDigits).GetHashCode();
            }
         }
         //Use:
         myList.Distinct(new RoundedXyzComparer(5));
