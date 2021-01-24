    foreach (HeaderFooter header in section.Headers)
    {
        if (header.LinkToPrevious) // || header.Index != WdHeaderFooterIndex.wdHeaderFooterFirstPage
        {
            continue;
        }
        header.Range.Select();
        // Add the fields in the header
        fields.AddRange(header.Range.Fields.Cast<Field>());
        // Add the fields in the shapes in the header
        var fieldsInShapes = ProcessShapes(header.Shapes.Cast<Shape>());
        fields.AddRange(fieldsInShapes);
    }
    foreach (HeaderFooter footer in section.Footers)
    {
        if (footer.LinkToPrevious) // || footer.Index != WdHeaderFooterIndex.wdHeaderFooterFirstPage
        {
            continue;
        }
        footer.Range.Select();
        // Add the fields in the footer
        fields.AddRange(footer.Range.Fields.Cast<Field>());
        // Add the fields in the shapes in the footer
        var fieldsInShapes = ProcessShapes(footer.Shapes.Cast<Shape>());
        fields.AddRange(fieldsInShapes);
    }
