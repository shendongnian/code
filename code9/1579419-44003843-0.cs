    private void main_tabControl_SelectedIndexChanged(object sender, EventArgs e) {
        for (int i = main_tabControl.TabPages.Count - 1; i >=0 ; i--) {
            if (main_tabControl.TabPages[i].Name.Equals("storage", StringComparison.OrdinalIgnoreCase) && main_tabControl.SelectedTab.Name != "Storage") {
                main_tabControl.TabPages.RemoveAt(i);
                break;
            }
       }
    }
