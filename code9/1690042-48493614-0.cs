    int i = 0;
        private void timerPaste_Tick(object sender, EventArgs e)
        {
            if (typeModebool == true && pasteModebool == false) //Check what mode is being used
            {
                if (i < amount) //If runs until i == amount
                {
                    SendKeys.Send(textBox1.Text);
                    SendKeys.Send("{Enter}");
                    amount--;
                }
                else
                {
                    timerPaste.Enabled = false;
                }
            }
            if (pasteModebool == true && typeModebool == false)
            {
                if (i < amount)
                {
                    Clipboard.SetText(textBox1.Text);
                    SendKeys.Send("^{c}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{Enter}");
                    amount--;
                }
                else
                {
                    timerPaste.Enabled = false;
                }
            }
        }
