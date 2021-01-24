        public Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane { get; set; }
        public CustomPaneUserControl cPaneUserControl = new CustomPaneUserControl();
       
       
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            myCustomTaskPane = Globals.ThisAddIn.CustomTaskPanes.Add(cPaneUserControl, "Verime");
            myCustomTaskPane.Width = 300;
            myCustomTaskPane.Visible = true;
            myCustomTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
        }
