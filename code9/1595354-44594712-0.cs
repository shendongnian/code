        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == (char)8) // backspace
                return;
            if (e.KeyChar == (char)3) // ctrl + c
                return;
            if (e.KeyChar == (char)22) // ctrl + v
                return;
            typedkey = true;
            if (_allowedCharacters.Count > 0) // if the string of allowed characters is not empty, skip test if empty
            {
                if (!_allowedCharacters.Contains(e.KeyChar)) // if the new character is not in allowed set,
                {
                    e.Handled = true; // ignoring it
                    return;
                }
            }
            if (_disallowedCharacters.Count > 0) // if the string of allowed characters is not empty, skip test if empty
            { 
                if (_disallowedCharacters.Contains(e.KeyChar)) // if the new character is in disallowed set,
                {
                    e.Handled = true; // ignoring it
                    return;
                }
            }
        }
