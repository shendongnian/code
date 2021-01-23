    public static Decimal GetAppSettingDecimal(String name) {
        
        String textualValue = ConfigurationManager.AppSettings[ name ];
        Decimal ret;
        return Decimal.TryParse( textualValue, NumberStyles.Number, CultureInfo.InvariantCulture, out ret ) ? ret : 0;
    }
    public static Decimal ServiceFee { get; } = GetAppSettingDecimal("ServiceFee");
