        Button clickedButton;
        private void mouseEnter(object sender, EventArgs e)
        {
            Button theBtn = (Button)sender;
            if(theBtn != clickedBtn)
                theBtn.BackColor = Color.Red;
        }
        private void mouseLeave(object sender, EventArgs e)
        {
            Button theBtn = (Button)sender;
            if (theBtn != clickedBtn)
                theBtn.BackColor = Color.Yellow;
        }
        private void buttonClick(object sender, EventArgs e)
        {
            setColor();//Calling this here so clickedBtn is still the old value
            Button theBtn = (Button)sender;
            clickedBtn = theBtn;
        }
        public void setColor()
        {
            clickedBtn.BackColor = Color.Yellow;
            //Resetting clicked button because another (or the same) was just clicked.
        }
