    public class DecimalAttribute : RegularExpressionAttribute {
        public DecimalAttribute() : base(@"\d+(\.\d{1,2})?") {
            this.ErrorMessage = "Invalid decimal";
        }
    }
