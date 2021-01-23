    private void CreateRadioButton()
    {
        int rbCount = 40;
            int numberOfColumns = 8;
            var radioButtons = new RadioButton[rbCount];
            int y = 20;
            for (int i = 0; i < rbCount; ++i)
            {
                radioButtons[i] = new RadioButton();
                radioButtons[i].Text = Convert.ToString(i);
                if (i%numberOfColumns==0)  y += 20; 
                var x = 514 + i%numberOfColumns * 37;
                radioButtons[i].Location = new Point(x, y);
                radioButtons[i].Size = new Size(37, 17);
                this.Controls.Add(radioButtons[i]);
            }
    }
