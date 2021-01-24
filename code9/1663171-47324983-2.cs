    class DbModelInfo
    {
        public string DateTimeType {get; set;}
        public byte DecimalScale {get; set;}
        public byte DecimalPrecision {get; set;}
        public static DbModelInfo Default
        {
             get
             {
                 return new DbModelInfo()
                 {
                     DateTimeType = "datetime2";
                     DecimalPrecistion = 19;
                     DecimalScale = 8;
                 }
             }
        }
        public static DbModelInfo UnitTesting {...}
    }
