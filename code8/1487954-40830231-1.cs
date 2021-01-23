    public class Square : Shape
    {
        // properties differ based on the shape.. 
        // eg: triangle needs height and base
        // edit CalculateArea method based on the shape
        public double Length { get; set; }
        public override double CalculateArea()
        {
            return Length * Length;
        }
    }
