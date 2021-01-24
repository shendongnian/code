     if (sidePanel.Width == 260)
    {
      
        sidePanel.Width = 0;
        panelProduct.Height = 0;
        panelOrdering.Height = 0;
        panel4.AutoScroll = false;
        PanelAnimator.HideSync(sidePanel);
    }
    else
    {
        
        sidePanel.Width = 260;
        panel4.AutoScroll = true;
        PanelAnimator.ShowSync(sidePanel);
    }
   
