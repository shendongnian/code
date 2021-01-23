    private void changeColor(string buttonName,System.Drawing.Color newColor)
        {
            Button b = (Button)Controls.Find(buttonName, true)[0];
            b.BackColor = newColor;
        }
