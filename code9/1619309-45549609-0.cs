    public static class LabelExtensions
     {
          public static string ConvertToDolar(this HtmlHelper helper, float amount)
          {
               return $"${amount};
          }
     }
