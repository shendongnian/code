    private void ShowFullToolsTimer_Tick(object sender, EventArgs e)
    {
        FonctionsNatives.dessinerOpenGL();
        if (editionToolsMenu.Width >= 200)
        {
            ShowFullTools.Stop();
            
            // start the other one
            HideFullMenu.Start();
        }
        else
        {
            editionToolsMenu.Width += 5; 
            if (HideFullMenu.Enabled)
            {
                HideFullMenu.Stop();
            }
        }            
    }
