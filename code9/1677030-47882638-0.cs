    public void ButtonClickHandler(Object sender, EventArgs e)
            {
                var currentButton = ((Button)sender);
                if(currentButton != null)
                {
                   currentButton.BackColor = currentButton.BackColor == Color.LightGreen ? Color.LightGray : Color.LightGreen;
                }
            }
