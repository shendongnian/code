        public void ButtonClickHandler(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.LightGreen)
            {
                ((Button)sender).BackColor = Color.White; // Your default color
            }
            else
            {
                ((Button)sender).BackColor = Color.LightGreen;
            }
        }
