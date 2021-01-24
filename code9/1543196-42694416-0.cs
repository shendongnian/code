            string keyInput = e.KeyChar.ToString();
            if (Char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }
            else if (e.KeyChar == ',')
            {
                // Comma key is OK
            }
            else
            {
                // Swallow this invalid key and beep
                e.Handled = true;
                //    MessageBeep();
            }
