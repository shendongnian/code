    Panel PanelTextBoxes = e.Item.FindControl("PanelTextBoxes") as Panel;
    Panel PanelTables = e.Item.FindControl("PanelTables") as Panel;
    if (e.Item.ItemIndex != 0)
    {
        PanelTextBoxes.Visible = false;
        PanelTables.Visible = false;
    }
