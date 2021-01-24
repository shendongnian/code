            Label clickedLabel;
            private void mouseEnter(object sender, EventArgs e)
            {
                Label theLabel = (Label)sender;
                if(theLabel != clickedLabel)
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
                Label theLabel = (Label)sender;
                clickedLabel = theLabel;
            }
