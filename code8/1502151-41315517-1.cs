    public class Currencies
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter amount to convert")]
            [DataType(DataType.Currency)]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public decimal CurrencyToConvert { get; set; }
    
    
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please select country Name")]
            public Currency fromCurrency { get; set; }
    
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please select country Name")]
            public Currency toCurrency { get; set; }
            
            public double ConvertedCurrency { get; set; }
        }
