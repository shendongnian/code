    using System;
    using System.Configuration;
    using System.IO;
    using System.Web.Mvc;
    
    namespace Enterprise.Apps.Shared.Web
    {
        /// <summary>
        /// Custom ViewEngine extension for RazorViewEngine designed to support physical paths (i.e. C:\Inetpub\shared\layouts -> \\server\share\layouts)
        /// </summary>
        /// <remarks>
        /// In .NET 4.5.2, physical paths are not supported in _ViewStart.cshtml due to Server.MapPath validation (only virtual paths allowed).
        /// This class provides an alternate ViewEngine to support shared layouts via physical paths as in the following:
        /// 
        /// net use \\server\share\layouts
        /// mklink /d C:\Inetpub\shared\layouts \\server\share\layouts
        /// </remarks>
        public class LayoutWrapperViewEngine : RazorViewEngine
        {
            public static readonly string HeaderPath = ConfigurationManager.AppSettings["LayoutView.HeaderPath"];
            public static readonly string FooterPath = ConfigurationManager.AppSettings["LayoutView.FooterPath"];
    
            protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
            {
                return new LayoutWrapperView(RenderViewWrapper, controllerContext, viewPath,
                    layoutPath: masterPath, runViewStartPages: true, viewStartFileExtensions: FileExtensions, viewPageActivator: ViewPageActivator);
            }
    
            /// <summary>
            /// Writes static header/footer to response buffer.
            /// </summary>
            /// <param name="body"></param>
            /// <param name="responseBuffer"></param>
            private static void RenderViewWrapper(Action body, TextWriter responseBuffer)
            {
                try
                {
                    responseBuffer.Write(File.ReadAllText(HeaderPath));
                } catch (Exception)
                {
                    // TODO: Implement exception handling
                }
    
                body();
    
                try
                {
                    responseBuffer.Write(File.ReadAllText(FooterPath));
                }
                catch (Exception)
                {
                    // TODO: Implement exception handling
                }
            }
        }
    }
