    public partial class ThisAddIn
    {
        public static Excel.Application e_application;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            e_application = this.Application;
            e_application.SheetTableUpdate += new Excel.AppEvents_SheetTableUpdateEventHandler(e_Application_SheetTableUpdate_Event);
        }
        private void e_Application_SheetTableUpdate_Event(object sender, Excel.TableObject target)
        {
            //--sender object refers to active sheet and must be cast as Worksheet before use
            //Update your dataset here
        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            e_application.SheetTableUpdate -= new Excel.AppEvents_SheetTableUpdateEventHandler(e_Application_SheetTableUpdate_Event);
            e_application = null;
        }
        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new Ribbon();
        }
	}
