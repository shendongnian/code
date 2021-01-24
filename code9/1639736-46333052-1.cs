    private void ShowHidePanels(bool visible)
    {
        for (var i = 0; i < 25; I++)
        {
             panels["panel" + i.ToString()].Visible = visible;
        }
    }
