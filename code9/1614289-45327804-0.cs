    using System;
    using Sitecore;
    using Sitecore.Mvc.Pipelines.Response.GetPageRendering;
    
    namespace MyProject.CMS.Custom.Pipelines.GetPageRendering 
    {
        public class GetCustomLayoutRendering : GetPageRenderingProcessor
        {
            public override void Process(GetPageRenderingArgs args)
            {
                if (args.Result == null)
                    return;
    
                if (!ShouldSwitchLayout()) //or whatever your custom logic is
                    return;
    
                args.Result.LayoutId = new Guid("{guid-to-alt-layout}");
                args.Result.Renderer = null;
            }
        }
    }
