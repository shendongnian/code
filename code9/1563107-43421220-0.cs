    public class FormViewModel {
        [DataType(DataType.Currency)]
        [Required, RegularExpression("[0-9,]")]
        public int? Amount { get; set; }
    }
