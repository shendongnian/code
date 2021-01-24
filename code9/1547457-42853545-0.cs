    public class ExtendFrontEndUrlHelper : FrontendUrlHelper
    {
        V_ExtendedURLsBuilder builder;
        public ExtendFrontEndUrlHelper(RequestContext requestContext) : base(requestContext)
        {
            // presumably you assigned builder here somehow
        }
        public new V_ExtendedURLsBuilder Sana 
        { get { return builder; } }
    }
