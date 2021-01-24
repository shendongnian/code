        ...
        {
            Config.DesignerSettings.DesignerLoaded += DesignerSettings_DesignerLoaded;
            Config.DesignerSettings.DesignerClosed += DesignerSettings_DesignerClosed;
            Report.ReportData.Design(false);
        }
        private void DesignerSettings_DesignerClosed(object sender, EventArgs e) {
            Config.DesignerSettings.DesignerLoaded -= DesignerSettings_DesignerLoaded;
            Config.DesignerSettings.DesignerClosed -= DesignerSettings_DesignerClosed;
        }
        private void DesignerSettings_DesignerLoaded(object sender, EventArgs e) {
            Report.ReportData.Designer.AskSave = false;
        }
