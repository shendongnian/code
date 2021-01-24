        private MyUserControl myUserControl1;
        private Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
                myUserControl1 = new MyUserControl();
                myCustomTaskPane = this.CustomTaskPanes.Add(myUserControl1, "My Task Pane");
                myCustomTaskPane.Visible = true;
        }
