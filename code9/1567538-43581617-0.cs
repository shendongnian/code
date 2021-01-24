    int x = 0;
    private void inputBox_KeyDown(object sender, KeyEventArgs e){
        try{
            if (e.KeyCode == Keys.Enter){
                itemHandler();
                inputBox.Clear();
            }
            if (e.KeyCode == Keys.Up){
                inputBox.Text = reload[x + 1];
                x++;
            }
            if (e.KeyCode == Keys.Down)(
                inputBox.Text = reload[x - 1];
                x--;
            }
            else {}
        }
            catch(Exception ex)
            {
                rtbDisplay.Text = "Error:" + ex.ToString();
            }
        }
