    private void crystalReportViewer1_ClickPage(object sender, CrystalDecisions.Windows.Forms.PageMouseEventArgs e)
                {
                    // Collect the report object name and type.
                    string msg = "Report Object: " + e.ObjectInfo.Name.ToString()
                        + " (" + e.ObjectInfo.ObjectType.ToString() + ")";
        
                    // Some report objects won't have text properties; verify that the property isn't null 
                    // before attempting to access it.
                    if (e.ObjectInfo.Text != null)
                    {
                        msg += "... Text: " + e.ObjectInfo.Text.ToString();
                    }
        
                    // Display the collected information in a message box.
                    MessageBox.Show(msg);
                }
