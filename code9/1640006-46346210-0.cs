        private void ShowControlSet(int ControlSet)
        {
            panel1.visible = false;
            panel2.visible = false;
            if (ControlSet == 1) panel1.visible = true;
            if (ControlSet == 2) panel2.visible = true;
        }
    
    // To show a panel use
    ShowControlSet(1);
