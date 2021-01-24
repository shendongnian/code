    List<SelectionRangeExt> selectionRanges = new List<SelectionRangeExt>(); 
    private void Button_Click(object sender, RoutedEventArgs e) 
    { 
        SelectionRangeExt range = new SelectionRangeExt(); 
        range.Start = richTextBoxAdv.Selection.Start.GetHierarchicalIndex; 
        range.End = richTextBoxAdv.Selection.End.GetHierarchicalIndex; 
        selectionRanges.Add(range); 
    } 
 
    public TextPosition GetTextPoistion(string hierarchicalIndex) 
    { 
        if (hierarchicalIndex == null) 
            return null; 
        return richTextBoxAdv.Document.GetTextPosition(hierarchicalIndex); 
    } 
