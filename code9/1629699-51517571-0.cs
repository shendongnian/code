     public bool AreColorsSimilar(Color c1, Color c2, int tolerance)
     {
         return Math.Abs(c1.R - c2.R) < tolerance &&
                Math.Abs(c1.G - c2.G) < tolerance &&
                Math.Abs(c1.B - c2.B) < tolerance;
     }
