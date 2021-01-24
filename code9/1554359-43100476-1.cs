    public class Line //class names should be Capitalized
    {
       public double X{ get; set; } //prop names should be Capitalized
       public double Y{ get; set; }
       public double L{
       	get{
          return Math.Sqrt(X * X + Y * Y);
       	}
       }
    }
