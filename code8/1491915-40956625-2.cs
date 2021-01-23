    public class CentimeterConverter : IConverter
    {
        private const double COEFFICENT = 0.3937;
        public string GetFormattedResult(int value)
        {
            var centimeter = input / COEFFICENT ;
            return $"In Centimeters: {centimeter}";
        }
    }
