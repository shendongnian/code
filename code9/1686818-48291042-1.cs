    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Web.Mvc;
    using System.Web.WebPages;
    
    namespace Enterprise.InHouse.Shared.Web
    {
        /// <summary>
        /// Primitive HTML template wrapper for RazorView where physical layout paths are unsupported.
        /// </summary>
        /// <remarks>
        /// Derived from https://github.com/mono/aspnetwebstack/blob/master/src/System.Web.Mvc/RazorView.cs
        /// </remarks>
        public class PhysicalPathView : RazorView
        {
            #region Proof of Concept (TODO: Refactor)
    
            public static readonly string HeaderPath = ConfigurationManager.AppSettings["PhysicalPathView.HeaderPath"];
            public static readonly string FooterPath = ConfigurationManager.AppSettings["PhysicalPathView.FooterPath"];
    
            // TODO: Optimize
            private static void StaticTemplateWrap(Action body, TextWriter writer)
            {
                writer.Write(File.ReadAllText(HeaderPath));
                body();
                writer.Write(File.ReadAllText(FooterPath));
            }
    
            #endregion
    
            #region RazorView
    
            public PhysicalPathView(ControllerContext controllerContext, string viewPath, string layoutPath, bool runViewStartPages, IEnumerable<string> viewStartFileExtensions)
                : this(controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions, null)
            {
            }
    
            public PhysicalPathView(ControllerContext controllerContext, string viewPath, string layoutPath, bool runViewStartPages, IEnumerable<string> viewStartFileExtensions, IViewPageActivator viewPageActivator)
                : base(controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions, viewPageActivator)
            {
                //LayoutPath = layoutPath ?? string.Empty; // ! Read-only
                //RunViewStartPages = runViewStartPages; // ! Read-only
                //StartPageLookup = StartPage.GetStartPage; // ! Non-existent
                //ViewStartFileExtensions = viewStartFileExtensions ?? Enumerable.Empty<string>(); // ! Read-only
            }
    
            protected override void RenderView(ViewContext viewContext, TextWriter writer, object instance)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }
    
                WebViewPage webViewPage = instance as WebViewPage;
                if (webViewPage == null)
                {
                    throw new InvalidOperationException(string.Format("Wrong view base: {0}", ViewPath));
                        //String.Format(
                        //    CultureInfo.CurrentCulture,
                        //    MvcResources.CshtmlView_WrongViewBase, // ! Non-existent
                        //    ViewPath));
                }
    
                // An overriden master layout might have been specified when the ViewActionResult got returned.
                // We need to hold on to it so that we can set it on the inner page once it has executed.
                //webViewPage.OverridenLayoutPath = LayoutPath; // ! Non-existent
                webViewPage.VirtualPath = ViewPath;
                webViewPage.ViewContext = viewContext;
                webViewPage.ViewData = viewContext.ViewData;
    
                webViewPage.InitHelpers();
    
                // ! Non-existent
                //if (VirtualPathFactory != null)
                //{
                //    webViewPage.VirtualPathFactory = VirtualPathFactory;
                //}
    
                // ! Non-existent
                //if (DisplayModeProvider != null)
                //{
                //    webViewPage.DisplayModeProvider = DisplayModeProvider;
                //}
    
                WebPageRenderingBase startPage = null;
    
                // ! Non-existent
                //if (RunViewStartPages)
                //{
                //    startPage = StartPageLookup(webViewPage, RazorViewEngine.ViewStartFileName, ViewStartFileExtensions);
                //}
    
                StaticTemplateWrap(() =>
                {
                    webViewPage.ExecutePageHierarchy(new WebPageContext(context: viewContext.HttpContext, page: null, model: null), writer, startPage);
                }, writer);
            }
    
            #endregion
        }
    }
