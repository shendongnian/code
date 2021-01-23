    static readonly DecimalParserAttribute _decimal = new DecimalParserAttribute();
    public static void Validate(Product product) {
        var sb = new StringBuilder();
        if(!_decimal.Parse(product.Weight)) {
           sb.Append(...);
        }
        // ... etc
        ...,
    }
