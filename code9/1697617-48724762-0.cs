    private void DiscoverPanels()
    {
        foreach (Control ctrl in panel5.Controls)
        {
            if (ctrl is Panel)
            {
                MessageBox.Show(ctrl.Name + " " + "is a child of panel5");
    
                foreach (Control grandchild in ctrl.Controls)
                {
                    if (grandchild is Panel)
                    {
                        MessageBox.Show(grandchild.Name + " " + "is a child of " + ctrl.Name);
                    }
                }
            }
    
        }
    }
