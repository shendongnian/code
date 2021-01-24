    namespace PowerPointAddIn1
    {
        public partial class ThisAddIn
        {
            public static int counter = 0;
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                this.Application.AfterNewPresentation += Application_AfterNewPresentation;
            }
        
            private void Application_AfterNewPresentation(PowerPoint.Presentation Pres)
            {
                int count = ++counter;
                UserControl1 uc = new UserControl1("task pane " + count);
                CustomTaskPane ctp = CustomTaskPanes.Add(uc, "custom task pane " + count);
                ctp.Visible = true;
            }
        
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
            protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
            {
                return new Ribbon1();
            }
        }
    }
