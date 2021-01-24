     private void toolStripViewOptions_Click(object sender, EventArgs e)
     {
                ToolStripMenuItem selectedOption = sender as ToolStripMenuItem;
    
                SetIndicationForSelectedOption(selectedOption);
     }
    private void SetIndicationForSelectedOption(ToolStripMenuItem selectedMenuItem)
    {
                ToolStripItemCollection menuItems = (contextMenuStrip.Items[(Int32)toolStripView.Tag] as ToolStripMenuItem).DropDownItems;
    
                // Set checked state for only the selected view option and disable same for others.
                foreach (ToolStripMenuItem item in menuItems)
                {
                    if (selectedMenuItem == item)
                        selectedMenuItem.Checked = true;
                    else
                        item.Checked = false;
                }
     }
