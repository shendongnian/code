    if(e.Index >= 0)
    {
        int index = e.Index;
        var brush = Brushes.Black;
        e.DrawBackground();
        e.Graphics.DrawString(lstTechnician[index].DisplayName.ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
        e.DrawFocusRectangle();
    }
    else
    {
        e.DrawBackground();
        e.DrawFocusRectangle();
    }
