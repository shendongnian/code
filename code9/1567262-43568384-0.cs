     if (range.Font.Subscript > 0 || range.Font.Superscript > 0)
     {
          foreach (var subItem in range.Words)
          {
               var supTempRange = doc.Paragraphs[i + 1].Range;
               supTempRange.Find.ClearFormatting();
               supTempRange.Find.Format = true;
               supTempRange.Find.Font.Superscript = 1;
               while (supTempRange.Find.Execute())
               {
                  MessageBox.Show(supTempRange.Text);
               }
              var subTempRange = doc.Paragraphs[i + 1].Range; 
              subTempRange.Find.ClearFormatting();
              subTempRange.Find.Format = true;
              subTempRange.Find.Font.Subscript = 1;
              while (subTempRange.Find.Execute())
              {
                  MessageBox.Show(subTempRange.Text);
              }
      }}
