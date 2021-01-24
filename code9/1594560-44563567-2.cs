    private void wantToAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (wanttoAnswer.SelectedItem?.ToString() == "Yes")
            {
                clothingCaughtFire.Visible = true;
                Refresh();
            }
            else
            {
                calledUs.SelectedIndex = -1;
                clothingCaughtFire.Visible = false;
                Refresh();
            }
        }
        private void calledUs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (calledUs.SelectedItem?.ToString() == "Yes - Other")
            {
                otherClothingFire.Visible = true;
                Refresh();
            }
            else
            {
                otherClothingFire.Visible = false;
                otherSpecify.Text = "";
                Refresh();
            }
        }
