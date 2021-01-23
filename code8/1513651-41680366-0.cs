        private void resetShiruken()
        {
            if ((reset ==  false) && (AIPoints < MAXPoints))
            {
                picShiruken.Location = new Point(ClientSize.Width / 2 - picShiruken.Width / 2, ClientSize.Height / 2 - picShiruken.Height / 2); //puts the picShiruken Picturebox in the middle anytime the picPlayerPaddle or picAIPaddle miss and is useful for counting the points of the computer and the player.
                reset = true;
            }
            TheWinner();
       }
    
    
      private void TheWinner()
        {
            while (reset == true)
            {
                    AIPoints += 1;
                    reset = false;
    
            }
            if (AIPoints >= AIPoints)
            {
                lblAIPoints.Text = AIPoints.ToString();
            }
            //resetShiruken();  <--- if you get rid of that call, should be fine.
        }
