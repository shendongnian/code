    public class LocalizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-CL");
            culture.NumberFormat.CurrencyDecimalDigits = 0;
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }
