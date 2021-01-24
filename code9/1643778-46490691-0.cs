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
			string[] choices = {"Select", "From", "Where"}; // three example of query words.
            Span span; // if you prefer a global one you can do that as well
            bool True = false; // set boolean standard to false.
			
            aLabel.Text = string.Empty; // clear your label text
            aLabel.FormattedText = string.Empty; // clear aslo your formatted label text to put there your colored text
            
			// Loop through the words the user typed.
			for (int i = 0; i < qInput.Length; i++)
            {
				// Also Loop through the choices of the words you want to set another color on.
                for (int j = 0; j < choices.Length; j++)
                {
					// check if a specific word is equal to one of the words you want to set another color on.
                    if (qInput[i] == choices[j])
                    {
						// if true, create a span with in this case the color red.
                        span = new Span
                        {
                            Text = qInput[i] + " ",
                            ForegroundColor = Color.Red,
                        };
						// Add the span to the FormattedText property of the Label
                        aLabel.FormattedText.Spans.Add(item: span);
						
						// set the bool to true, because this word is colored red.
                        True = true;
                    }
                    else
                    {
                        // Do nothing.
                    }
                }
				
				// if the word isn't yet set in the span.
                if (!True)
                {
					// create a span with a default color black
                    span = new Span
                    {
                        Text = qInput[i] + " ",
                        ForegroundColor = Color.Black,
                    };
                    aLabel.FormattedText.Spans.Add(item: span);
                }
                else
                {
					// set boolean to false to go to the next word.
                    True = false;
                }
            }
 
