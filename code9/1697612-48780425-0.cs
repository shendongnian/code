        public void DisableGroup(Fluent.RibbonGroupBox ribbonGroup, string reasonOfDisable)
        {
            foreach (var item in ribbonGroup.Items)
            {
                if (item is Fluent.Button)
                {
                    DisableButton((Fluent.Button)item, reasonOfDisable);
                }
            }
        }
        public void DisableButton(Fluent.Button button, string reasonOfDisable)
        {
            button.IsEnabled = false;
            if (button.ToolTip is Fluent.ScreenTip)
            {
                Fluent.ScreenTip screenTip = (Fluent.ScreenTip)button.ToolTip;
                screenTip.DisableReason = reasonOfDisable;
            }
        }
