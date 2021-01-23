    private void textBox_KeyDown(object sender, KeyEventArgs e)
            {
                string pressedKey = e.Key.ToString(); //It will be always uppercase no need for case sensitivity checks
                bool keyNotAllowed;
    
                // here apply your logic to determine if the key is allowed
    
                if (keyNotAllowed)
                {
                    e.Handled = true;
                }
            }
