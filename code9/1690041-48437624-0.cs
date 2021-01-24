      timerPaste.Elapsed += OnTickEvent;
        
        private async void OnTickEvent(Object source,EventArgs e)
        {
                interval = Int32.Parse(interNum.Text);
                timerPaste.Interval = interval;
        
                if (typeModebool == true && pasteModebool == false)
                {
                    while (amount > 0) //Need to find a way to make GUI responsive during while loop.
                    {
                        SendKeys.Send(textBox1.Text);
                        SendKeys.Send("{Enter}");
                        amount--;
                    }
                    timerPaste.Enabled = false;
                    amount = Int32.Parse(amountSetBox.Text);
                }
        
                if (pasteModebool == true && typeModebool == false)
                {
                    while (amount > 0) //Need to find a way to make GUI responsive during while loop.
                    {
                        Clipboard.SetText(textBox1.Text);
                        SendKeys.Send("^{c}");
                        SendKeys.Send("^{v}");
                        SendKeys.Send("{Enter}");
                        amount--;
                    }
       
             timerPaste.Enabled = false;
                amount = Int32.Parse(amountSetBox.Text);
            }
        }
