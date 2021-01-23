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
            RichTextBox rtb = ClRichTextBox; //the name of your richtextbox control
            TextPointer currentStartposition = rtb.Selection.Start;
            TextPointer currentEndposition = rtb.Selection.End;
            TextPointer position;
            TextPointer previousPosition;
            string textLine = null;
            if (direction == LogicalDirection.Forward)
            {
                position = currentStartposition.GetLineStartPosition(1);
                previousPosition = currentEndposition;
                if (position != null)
                    textLine = new TextRange(previousPosition, position).Text;
            }
            else
            {
                position = currentStartposition.GetLineStartPosition(0);
                previousPosition = currentStartposition;
                if (position != null)
                    textLine = new TextRange(position, previousPosition).Text;
            }
            while (position != null)
            {
                int indexInRun;
                if (direction == LogicalDirection.Forward)
                    indexInRun = textLine.IndexOf(input, StringComparison.CurrentCultureIgnoreCase);
                else
                    indexInRun = textLine.LastIndexOf(input, StringComparison.CurrentCultureIgnoreCase);
                if (indexInRun >= 0)
                {
                    TextPointer nextPointer = null;
                    if (direction == LogicalDirection.Forward)
                        position = previousPosition;
                    int inputLength = input.Length;
                    while (nextPointer == null)
                    {
                        if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text && nextPointer == null) //checks to see if textpointer is actually text
                        {
                            string textRun = position.GetTextInRun(LogicalDirection.Forward);
                            if (textRun.Length - 1 < indexInRun)
                                indexInRun -= textRun.Length;
                            else //found the start position of text pointer
                            {
                                position = position.GetPositionAtOffset(indexInRun);
                                nextPointer = position;
                                while (inputLength > 0)
                                {
                                    textRun = nextPointer.GetTextInRun(LogicalDirection.Forward);
                                    if (textRun.Length - indexInRun < inputLength)
                                    {
                                        inputLength -= textRun.Length;
                                        indexInRun = 0; //after the first pass, index in run is no longer relevant
                                    }
                                    else
                                    {
                                        nextPointer = nextPointer.GetPositionAtOffset(inputLength);
                                        rtb.Selection.Select(position, nextPointer);
                                        rtb.Focus();
                                        //moves the scrollbar to the selected text
                                        Rect r = position.GetCharacterRect(LogicalDirection.Forward);
                                        double totaloffset = r.Top + rtb.VerticalOffset;
                                        rtb.ScrollToVerticalOffset(totaloffset - rtb.ActualHeight / 2);
                                        return; //word is selected and scrolled to. Exit method
                                    }
                                    nextPointer = nextPointer.GetNextContextPosition(LogicalDirection.Forward);
                                }
                                
                            }
                        }
                        position = position.GetNextContextPosition(LogicalDirection.Forward);
                    }
                }
                previousPosition = position;
                if (direction == LogicalDirection.Forward)
                {
                    position = position.GetLineStartPosition(1);
                    if (position != null)
                        textLine = new TextRange(previousPosition, position).Text;
                }
                else
                {
                    position = position.GetLineStartPosition(-1);
                    if (position != null)
                        textLine = new TextRange(position, previousPosition).Text;
                }
            }
            //if next/previous word is not found, leave the current selected word selected
            rtb.Selection.Select(currentStartposition, currentEndposition);
            rtb.Focus();
        }
