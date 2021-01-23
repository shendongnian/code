        //Comfirming the chosen letter.
        private void btnRightValueChanged(GpioPin sender, GpioPinValueChangedEventArgs e)
        {
            if (e.Edge == GpioPinEdge.FallingEdge)
            {
                stopWatch = new Stopwatch();
                stopWatch.Start();
            }
            if (e.Edge == GpioPinEdge.RisingEdge)
            {
                stopWatch.Stop();
                long duration = stopWatch.ElapsedMilliseconds;
                if (duration > 2000 )
                {
                    SendWord();
                }
                else
                {
                    //Add the current character to the word
                    _currentWordSB.Append(Convert.ToString(_currentChar));
                //    //Reset currentChar aswell
                    _currentChar = ' ';
                //    //The user confirmed the morse sequence and wants to start a new one, so we reset it.
                    _morseCode.Clear();
                //    //Preview the word
                    PreviewLetter();
                }
            }
        }
