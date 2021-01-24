    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Mvc;
    
    namespace Enterprise.Apps.Shared.Web
    {
        public class LayoutWrapperView : RazorView
        {
            /// <summary>
            /// Outer lambda for caller to wrap inner lambda.
            /// </summary>
            private readonly Action<Action, TextWriter> RenderViewWrapper;
    
            public LayoutWrapperView(Action<Action, TextWriter> renderViewWrapper, ControllerContext controllerContext, string viewPath, string layoutPath, bool runViewStartPages, IEnumerable<string> viewStartFileExtensions)
                : this(renderViewWrapper, controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions, null) { }
    
            public LayoutWrapperView(Action<Action, TextWriter> renderViewWrapper, ControllerContext controllerContext, string viewPath, string layoutPath, bool runViewStartPages, IEnumerable<string> viewStartFileExtensions, IViewPageActivator viewPageActivator)
                : base(controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions, viewPageActivator)
            {
                RenderViewWrapper = renderViewWrapper;
            }
    
            protected override void RenderView(ViewContext viewContext, TextWriter writer, object instance)
            {
                if (RenderViewWrapper != null)
                {
                    RenderViewWrapper(() =>
                    {
                        base.RenderView(viewContext, writer, instance);
                    }, writer);
                } else
                {
                    base.RenderView(viewContext, writer, instance);
                }
            }
        }
    }
