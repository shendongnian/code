    MouseDownStartPosition = e.GetPosition(textBox);
    
    //check if user clicked some exact character
    var characterIndexFalse = textBox.GetCharacterIndexFromPoint(MouseDownStartPosition, false);
    //get nearest character to mouse
    var characterIndex = textBox.GetCharacterIndexFromPoint(MouseDownStartPosition, true);
                    
    //GetCharacterIndexFromPoint often returns last but one character position when clicked right after textbox
    //so check if characterIndexFalse is -1 (text not clicked) and if nearest character is last but one, assume that 
    //user clicked behind string
    if ((characterIndexFalse == -1) && (characterIndex + 1 == textBox.Text.Length)) {
       characterIndex++;
    }
