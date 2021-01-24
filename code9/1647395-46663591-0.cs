    private void gridShop_ViewCellFormatting(object sender, CellFormattingEventArgs e)
    {
        if (e.CellElement is GridHeaderCellElement && e.Column.Name == "IDCol")
            (e.CellElement as GridHeaderCellElement).FilterButton.Visibility = ElementVisibility.Collapsed;
    }
