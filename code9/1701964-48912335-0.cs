        Outlook.Explorer explorer;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            explorer = Application.ActiveExplorer();
            explorer.SelectionChange += new Outlook.ExplorerEvents_10_SelectionChangeEventHandler(explorer_SelectionChange);
        }
        void explorer_SelectionChange()
        {
            if(0 == Application.ActiveExplorer().Selection.Count)
            {
                // On start up there are no selections so do nothing...
                return;
            }
            // Get the first mail item
            var item = Application.ActiveExplorer().Selection[1];
            //
            if (item is Outlook.MailItem)
            {
                MessageBox.Show("Selected email's subject: " + ((Outlook.MailItem)item).Subject);
            }
        }
