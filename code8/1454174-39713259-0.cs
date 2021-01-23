    public struct Complex
    {
        public static readonly ImaginaryOne = new Complex(0, 1);
        public doube Real { get; }
        public double Imaginary { get; }
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
    }
