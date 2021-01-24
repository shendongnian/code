    public class LocalizedViewModel {
       private IFormatProvider formatProvider;
       public float Currency { get; set; }
       public string FormattedCurrency () {
         if (formatProvider.ToString().Equals("en-US"))
         {
             return  (this.Currency < 0 ? this.Currency.ToString("C", formatProvider) : (this.Currency).ToString("C", formatProvider));
         }
         else
         {
             return (this.Currency < 0 ? "- " + Math.Abs(this.Currency).ToString("C", formatProvider) : (this.Currency).ToString("C", formatProvider));
         }
       }
      public LocalizedViewModel () {
        formatProvider = System.Globalization.CultureInfo.CurrentCulture;
      }
    }
