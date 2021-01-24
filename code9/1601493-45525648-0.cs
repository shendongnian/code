     TextRange selectionTextRange = new TextRange(rtb.Selection.Start, rtb.Selection.End);
     SolidColorBrush newBrush = null;
     newBrush = (SolidColorBrush)selectionTextRange.GetPropertyValue(TextElement.BackgroundProperty);
     SolidColorBrush newBrush2 = null;
     newBrush2 = (SolidColorBrush)rtb.Selection.Start.Paragraph.Background;
     SolidColorBrush newBrush3 = null;
     try {
         newBrush3 = (SolidColorBrush)((Span)((Run)rtb.Selection.Start.Parent).Parent).Background;
     }
     catch (Exception ex) {
         //Selection Parent is Run
         //Run Parent can be Span, Paragraph, etc.
         //Parent is not Span
     }
     if (newBrush == null) {
         if (newBrush2 == null) {
             if (newBrush3 == null) {
                 ClrPcker_Bg.SelectedColor = Colors.Transparent;
              }
              else {
                  ClrPcker_Bg.SelectedColor = newBrush3.Color;
              }
          }
          else {
              ClrPcker_Bg.SelectedColor = newBrush2.Color;
          }
      }
      else {
          ClrPcker_Bg.SelectedColor = newBrush.Color;
      }
