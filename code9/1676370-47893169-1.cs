    namespace PowerPointAddIn1
    {
        [ComVisible(true)]
        public class Ribbon1 : Office.IRibbonExtensibility
        {
            private Office.IRibbonUI ribbon;
            public Ribbon1()
            {
            }
            public void toggleTaskPane(Office.IRibbonControl control, bool enabled)
            {
                var CTPs = Globals.ThisAddIn.CustomTaskPanes;
                var pres = Globals.ThisAddIn.Application.ActivePresentation;
            
                foreach (var x in CTPs)
                {
                    if (pres.Name.EndsWith(x.Title.Replace("custom task pane ", "")))
                    {
                        x.Visible = enabled;
                    }
                }
            }
            public bool isPressed(Office.IRibbonControl control)
            {
                var CTPs = Globals.ThisAddIn.CustomTaskPanes;
                var pres = Globals.ThisAddIn.Application.ActivePresentation;
                foreach (var x in CTPs)
                {
                    if (pres.Name.EndsWith(x.Title.Replace("custom task pane ", "")))
                    {
                        return x.Visible;
                    }
                }
                return false;
            }
        }
    }
