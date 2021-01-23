    public interface IPortalCodeProvider
    {
        int GetPortalCode();
    }
    public class PortalCodeProvider : IPortalCodeProvider
    {
        public const string PortalCodeQueryStringKey = "PortalCode";
        public const int DefaultPortalCode = 123;
        public int GetPortalCode()
        {
            var portalCodeString = HttpContext.Current.Request.QueryString[PortalCodeQueryStringKey];
            int portalCode;
            if (int.TryParse(portalCodeString, out portalCode)) return portalCode;
            else return DefaultPortalCode;
        }
    }
