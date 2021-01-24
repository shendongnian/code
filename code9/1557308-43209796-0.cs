     Windows.UI.Text.ITextSelection selectedText = myRichTextBox.Document.Selection;
     if (selectedText != null)
     {
         Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
         charFormatting.Size = 18; //Or whatever
         selectedText.CharacterFormat = charFormatting;
     }
