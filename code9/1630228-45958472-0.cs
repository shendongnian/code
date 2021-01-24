    private void AddScheduleFile(RadCollapsiblePanel blockPanel, PlaylistElement element)
    {
        var panel = new ScheduleControls.FilePanel(element);
        panel.FileOpen += Panel_FileOpen;
        blockPanel.Controls.Add(panel);
    }
    
