        if (DealerScore == 21)
        {
            MessageBox.Show("Dealer Scored blackjack");
        }
        // dealer loses
        else if (DealerScore > 21)
        {
            MessageBox.Show("Dealer bust. Player wins");
        }
     
