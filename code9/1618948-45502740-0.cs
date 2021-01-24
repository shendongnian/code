        public static int Compare(string a, string b)
        {
            // Locate point (if exists)
            var pointA = a.IndexOf('.'); 
            if(pointA == -1)
                pointA = a.Length;
            var pointB = a.IndexOf('.'); 
            if(pointB == -1)
                pointB = a.Length;
            // Get integers
            var intA = int.Parse(a.Substring(0, pointA));
            var intB = int.Parse(b.Substring(0, pointA));
            if(intA == intB)
            {
                // Get fractionals
                intA = int.Parse(a.Substring(pointA+1));
                intB = int.Parse(b.Substring(pointB+1));
            }
            return intB-intA;
        }
