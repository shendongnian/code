    class Persoon
    {
        public string Naam { get; set; }
        public string Geslacht { get; set; }
        public double Gewicht { get; set; }
        public double Lengte { get; set; }
        public double Bmi { get; set; }
        public Persoon(string nm, string gt, double wt, double le)
        {
            Naam = nm;
            Geslacht = gt;
            Gewicht = wt;
            Lengte = le;
        }
        public double BMI()
        {
            return Gewicht / Math.Pow(Lengte / 100.0, 2);
        }
        public override string ToString()
        {
            return $"Persoon: {Naam} {Geslacht}";
        }
    }
