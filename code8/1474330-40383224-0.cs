      using System.Windows.Forms;
      private void card1_Click(object sender, EventArgs e)
         //if the first slot of pendingImages is available put this card there for comparison
    {
        //turn card over
        card1.Image = Properties.Resources.Image1;
       //if this is the first card to be turned over, save its image 
        if (pendingImage1 == null)
        {
            pendingImage1 = card1;
        }
        //else check if pendingImage 2 is available then store the card here for comparison
        else if(pendingImage1 != null && pendingImage2 == null)
        {
            pendingImage2 = card1;
        }
        //if both pendingImage slots are filled then compare the cards
        if (pendingImage1 != null && pendingImage2 != null)
        {
            if (pendingImage1.Tag == pendingImage2.Tag)
            {
                //clear the variables to be used again
                pendingImage1 = null;
                pendingImage2 = null;
                //once the cards are matched and turned permanentaly, disable the card to make it unclickable
                card1.Enabled = false;
                dupCard1.Enabled = false;
                //add 10 points to the score evry time cards match
                scoreSheet.Text = Convert.ToString(Convert.ToInt32(scoreSheet.Text) + 10);
                int TotalPoints = Convert.ToInt32(scoreSheet.Text);
                if(TotalPoints >= 100){
                        MessageBox.Show("Your message");
                }
            }
            else
            {
                flipDuration.Start();
            }
        }
    }
    private void dupCard1_Click(object sender, EventArgs e)
    {
        dupCard1.Image = Properties.Resources.Image1;
        if (pendingImage1 == null)
        {
            pendingImage1 = dupCard1;
        }
        else if (pendingImage1 != null && pendingImage2 == null)
        {
            pendingImage2 = dupCard1;
        }
        if (pendingImage1 != null && pendingImage2 != null)
        {
            if (pendingImage1.Tag == pendingImage2.Tag)
            {
                pendingImage1 = null;
                pendingImage2 = null;
                card1.Enabled = false;
                dupCard1.Enabled = false;
                scoreSheet.Text = Convert.ToString(Convert.ToInt32(scoreSheet.Text) + 10);
                int TotalPoints = Convert.ToInt32(scoreSheet.Text);
                if(TotalPoints >= 100){
                        MessageBox.Show("Your message");
                }
            }
            else
            {
                flipDuration.Start();
            }
        }
    }
