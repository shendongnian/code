    class Model
    {
        public string Description {get; set;}
        public string Length {get; set;}
        private static IFormatProvider spanishCulture = CultureInfo.CreateSpecificCulture("es-ES");
        [NotMapped]
        public decimal LengthInMeters
        {
            get {return Decimal.Parse(this.Length, spanishCulture);}
            set {this.Length = value.ToString(spanishCulture); }
        }
    }
