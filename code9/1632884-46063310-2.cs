    private void GenerateContent(DataTemplate itemsPanel, DataTemplate itemTemplate, IEnumerable itemsSource)
    {
    ....
        if (panel is Section)
            ((Section)panel).Blocks.Add(Helpers.ConvertToBlock(data, element));
        else if (panel is TableRowGroup)
            ((TableRowGroup)panel).Rows.Add((TableRow)element);
        else if (panel is Paragraph && element is Inline)
            ((Paragraph)panel).Inlines.Add((Inline)element);
        else
            throw new Exception(String.Format("Don't know how to add an instance of {0} to an instance of {1}", element.GetType(), panel.GetType()));
