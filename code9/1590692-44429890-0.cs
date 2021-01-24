    public class SolidColorBrushComparer : IEqualityComparer<SolidColorBrush>
    {      
        public bool Equals(SolidColorBrush x, SolidColorBrush y)
        {
            // If you do not care about opacity, disregard it.
            return x.Color == y.Color && 
                x.Opacity == y.Opacity;
        }
    
        public int GetHashCode(SolidColorBrush obj)
        {
            return new { C = obj.Color, O = obj.Opacity }.GetHashCode();
        }
    }
