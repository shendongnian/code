    namespace WordAddIn2
    {
        public partial class ThisAddIn
        {
            SidePane sP;
            private Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;
    
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                sP = new SidePane();
                myCustomTaskPane = this.CustomTaskPanes.Add(sP, "Title");
                myCustomTaskPane.Visible = true;
            }
    
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
    
            #region VSTO generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InternalStartup()
            {
                this.Startup += new System.EventHandler(ThisAddIn_Startup);
                this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            }
            
            #endregion
        }
    }
