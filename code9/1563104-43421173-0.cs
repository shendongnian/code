    public class FormViewModel {
        public string Amount { get; set; }
    
        public int? Value {
            get {
                int result = 0;
                if (Int32.TryParse(Amount, NumberStyles.Currency, CultureInfo.CurrentCulture, result) {
                    return result;
                }
                return null;
            }
        }
    }
