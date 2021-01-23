        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            SelectWord(SearchTextbox.Text, LogicalDirection.Backward);
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            SelectWord(SearchTextbox.Text, LogicalDirection.Forward);
        }
        /// <summary>
        /// Takes a string input and searches richtextbox in the direction specified.  
        /// </summary>
        private void SelectWord(string input, LogicalDirection direction)
        {
            RichTextBox richTextBox = ClRichTextBox; //the name of your richtextbox control
            TextPointer currentStartposition = richTextBox.Selection.Start;
            TextPointer currentEndposition = richTextBox.Selection.End;
            TextPointer position;
            if (direction == LogicalDirection.Forward)
                position = currentEndposition;
            else
                position = currentStartposition;
            while (position != null)
            {
                if (direction == LogicalDirection.Forward && position.CompareTo(richTextBox.Document.ContentEnd) == 0)
                    break;
                else if (direction == LogicalDirection.Backward && position.CompareTo(richTextBox.Document.ContentStart) == 0)
                    break;
                if (position.GetPointerContext(direction) == TextPointerContext.Text) //checks to see if textpointer is actually text
                {
                    string textRun = position.GetTextInRun(direction);
                    int indexInRun;
                    if (direction == LogicalDirection.Forward)
                        indexInRun = textRun.IndexOf(input, StringComparison.CurrentCultureIgnoreCase);
                    else
                        indexInRun = textRun.LastIndexOf(input, StringComparison.CurrentCultureIgnoreCase);
                    if (indexInRun >= 0) //search text found
                    {
                        TextPointer nextPointer;
                        if (direction == LogicalDirection.Forward)
                            position = position.GetPositionAtOffset(indexInRun);
                        else
                            position = position.GetPositionAtOffset(indexInRun - textRun.Length);
                        nextPointer = position.GetPositionAtOffset(input.Length);
                        richTextBox.Selection.Select(position, nextPointer);
                        richTextBox.Focus();
                        //moves the scrollbar to the selected text
                        Rect r = position.GetCharacterRect(direction);
                        double totaloffset = r.Top + richTextBox.VerticalOffset;
                        richTextBox.ScrollToVerticalOffset(totaloffset - richTextBox.ActualHeight / 2);
                        return; //word is selected and scrolled to. Exit method
                    }
                    else if (direction == LogicalDirection.Forward)
                        position = position.GetPositionAtOffset(textRun.Length); // If a match is not found, go over to the next context position after the "textRun".
                    else
                        position = position.GetPositionAtOffset(-textRun.Length); // If a match is not found, go over to the next context position before the "textRun".
                }
                else //If the current position doesn't contain text i.e. you are at a position where the XAML represents formatting or some embeded element symbols
                {
                    position = position.GetNextContextPosition(direction); 
                    if (direction == LogicalDirection.Backward) //if moving backward, the first move takes you back to the beginning of textpointer. Need to move again to get next texpointer
                        position = position.GetNextContextPosition(direction);
                }
            }
            //if next/previous word is not found, leave the current selected word selected
            richTextBox.Selection.Select(currentStartposition, currentEndposition);
            richTextBox.Focus();
        }
