        private void Form1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string keyword = "";
            var selectedMenuItem = this.menuStrip1.Descendants()
                .Where(x => x.Selected).FirstOrDefault();
            if (selectedMenuItem != null)
                keyword = selectedMenuItem.Tag?.ToString();
            else if (ActiveControl != null)
                keyword = helpProvider1.GetHelpKeyword(ActiveControl);
            if (!string.IsNullOrEmpty(keyword))
                Help.ShowHelp(this, "Help.chm", HelpNavigator.Index, keyword);
        }
