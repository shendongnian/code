        Label clickedLabel;
        private void mouseEnter(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.Red;
        }
        private void mouseLeave(object sender, EventArgs e)
        {
            Label theLabel = (Label)sender;
            if (theLabel != clickedLabel)
                theLabel.BackColor = Color.Yellow;
        }
        private void labelClick(object sender, EventArgs e)
        {
            setColor();//Calling this here so clickedLabel is still the old value
            Label theLabel = (Label)sender;
            clickedLabel = theLabel;
        }
        public void setColor()
        {
            if(clickedLabel != default(Label))
                clickedLabel.BackColor = Color.Yellow;
            //Resetting clicked label because another (or the same) was just clicked.
        }
