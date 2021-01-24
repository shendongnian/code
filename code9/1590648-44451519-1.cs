    public class CsvExportStringSpacingConverter : DefaultTypeConverter {
        private const string Space = " ";
    
        public override string ConvertToString(TypeConverterOptions options, object value) {
            return Space + value + Space;
        }
    }
