    List<SelectionRangeExt> selectionRanges = new List<SelectionRangeExt>(); 
    /// <summary> 
    /// Saves the selection start and end indexes into collection. 
    /// </summary> 
    /// <param name="sender"></param> 
    /// <param name="e"></param> 
    private void Button_Click(object sender, RoutedEventArgs e) 
    { 
        SelectionRangeExt range = new SelectionRangeExt(); 
        range.Start = richTextBoxAdv.Selection.Start.GetHierarchicalIndex; 
        range.End = richTextBoxAdv.Selection.End.GetHierarchicalIndex; 
        selectionRanges.Add(range); 
    } 
    /// <summary> 
    /// Gets the TextPosition from the given hierarchical index. 
    /// </summary> 
    /// <param name="hierarchicalIndex">The hierarchical index.</param> 
    /// <returns>The <see cref="TextPosition"/> instance.</returns> 
    public TextPosition GetTextPoistion(string hierarchicalIndex) 
    { 
        if (hierarchicalIndex == null) 
            return null; 
        return richTextBoxAdv.Document.GetTextPosition(hierarchicalIndex); 
    } 
 
