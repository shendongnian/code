        string[] buttonNames = new string[3] {"Fancy Button 1", "Boring button two", "Uh whats that button"};
        for (int i = 0; i != amount.Length; i++)
        {
            if (amount[i] > 0)
            {
                Control button = this.Controls[buttonNames[i] ];
                button.Visible = true;
            }
        }
