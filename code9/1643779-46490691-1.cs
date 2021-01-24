        private string[] wordsRed = { "Select", "From", "Where"}; // some examples
        private bool isSpecialColor = false;
        private Span span;
        /// <summary>
        /// Handles the text changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = e.NewTextValue;
            string[] qInput = input.Split(' ');
            CheckInput(qInput);
        }
        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <param name="qInput">Q input.</param>
        private void CheckInput(string[] qInput)
        {
            // Check if the last typed character is a word separator.
            if (input[input.Length-1] == ' ') 
            {
                //
                // Loop through the string[] with the words you want to give a color on.
                //
                for (int i = 0; i < wordsRed.Length; i++)
                {
                    //
                    // Check on the last word that is typed
                    //
                    if (qInput[qInput.Length-1] == wordsRed[i])
                    {
                        // Create a span with the word and color the foreground red
                        span = new Span
                        {
                            Text = qInput[qInput.Length-1] + " ",
                            ForegroundColor = Color.Green,
                        };
                        // Add the span to the Label
                        aLabel.FormattedText.Spans.Add(item: span);
                        // set boolean true because there is made a span with a red foreground.
                        isSpecialColor = true;
                    }
                    else
                    {
                        // Do nothing.
                    }
                }
                // Check if the word altready is colored.
                if (isSpecialColor)
                {
                    // Set the boolean to false for the next check.
                    isSpecialColor = false;
                }
                else
                {
                    // Create span with the word and color it black.
                    span = new Span
                    {
                        Text = qInput[i] + " ",
                        ForegroundColor = Color.Black,
                    };
                    aLabel.FormattedText.Spans.Add(item: span);
                }
            }
            else 
            {                
                // Do nothing.
            }
        }
 
