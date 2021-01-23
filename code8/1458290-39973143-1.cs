        private void ExpandStateChangedHandler(object sender, EventArgs e)
        {
            var currentPanel = (ExpandPanel)sender;
            if (currentPanel.IsExpanded == false)
            {
                return;
            }
            foreach(var panel in panels)
            {
                if (panel.Name != currentPanel.Name)
                {
                    panel.IsExpanded = false;
                }
            }
        }
