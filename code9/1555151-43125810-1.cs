        string[] buttonNames = new string[3] {"button1", "button2", "button3" };
        for (int i = 0; i != amount.Length; i++)
        {
            if (amount[i] > 0)
            {
                Control button = this.Controls[buttonNames[i] ];
                button.Visible = true;
            }
        }
