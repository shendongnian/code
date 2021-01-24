    public class MediaRequestHandler : Sitecore.Resources.Media.MediaRequestHandler
    {
        protected override bool DoProcessRequest(HttpContext context, Sitecore.Resources.Media.MediaRequest request,
                    Sitecore.Resources.Media.Media media)
        {    
            if (!string.IsNullOrEmpty(context.Request.QueryString["type"]))
            {
                request.Options.Height = 120;//desired height here
                request.Options.Width = 180;//desired width here
            }
    
            return base.DoProcessRequest(context, request, media);
        }
    }
