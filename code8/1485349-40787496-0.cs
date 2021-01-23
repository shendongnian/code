    abstract class GraphicAttributes
    {
        public double Diameter { get; protected set; }
        public double Distance { get; protected set; }
        public double Str1 { get; protected set; }
        public double? Str2 { get; protected set; }
        public GraphicAttributes(double diameter, double distance, string str1, string str2)
        {
            // load all attributes plain-vanilla - let the subclasses adjust as necessary
            Diameter = diameter;
            Distance = distance;
            Str1 = double.Parse(str1, System.Globalization.CultureInfo.InvariantCulture);
            Str2 = String.IsNullOrEmpty(str2)
                ? new Nullable<double>()
                : double.Parse(str2, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
    class FeatureTypeF : GraphicAttributes
    {
        public FeatureTypeF(double diameter, double distance, string str1, string str2)
            : base(diameter, distance, str1, str2)
        {
            Str1 = -Str1;
        }
    }
    class FeatureTypeL : GraphicAttributes
    {
        public FeatureTypeL(double diameter, double distance, string str1, string str2)
            : base(diameter, distance, str1, str2)
        {
            if (Str2.HasValue)
                Str2 = new Nullable<double>(-(Str2.Value));
        }
    }
    class GraphicAttributeFactory
    {
        public static GraphicAttributes GetGraphicAttributes(string featureType, double diameter, double distance, string str1, string str2)
        {
            if (featureType.Contains("F"))
                return new FeatureTypeF(diameter, distance, str1, str2);
            if (featureType.Contains("L"))
                return new FeatureTypeL(diameter, distance, str1, str2);
            // add more implementations here
            throw new Exception("Unexpected featureType!");
        }
    }
    // and then your final method looks like:
    private void Choose(string featureType, double diameter, double distance, string str1, string str2)
    {
        GraphicAttributes ga = GraphicAttributeFactory.GetGraphicAttributes(featureType, diameter, distance, str1, str2);
        if (ga.Str2.HasValue)
            CreateChamfer(ga.Diameter, ga.Distance, ga.Str1, ga.Str2.Value);
        else
            CreateFillet(ga.Diameter, ga.Distance, ga.Str1);
    }
