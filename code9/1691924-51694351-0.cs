    using Excel = Microsoft.Office.Interop.Excel;
    using Office = Microsoft.Office.Core;
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        Excel.Application excelApp = Globals.ThisAddIn.Application;
        excelApp.CommandBars.OnUpdate += new Office._CommandBarsEvents_OnUpdateEventHandler(CommandBars_OnUpdate);
        //Other code to be executed at startup
    }
    private void CommandBars_OnUpdate()
    {
            Excel.Application excelApp = Globals.ThisAddIn.Application;
            Excel.Chart activeChart = null;
            try
            {
                activeChart = excelApp.ActiveChart;
                if (activeChart != null)
                {
                    //Code to be triggered
                }
            }
            catch
            {
            }
    }
