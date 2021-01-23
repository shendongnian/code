    using System.Globalization;
    public static decimal ServiceFee { get; } =
            Decimal.Parse(
                ConfigurationManager.AppSettings["ServiceFee"] ?? "0",
                NumberStyles.Number,
                CultureInfo.InvariantCulture
            );
