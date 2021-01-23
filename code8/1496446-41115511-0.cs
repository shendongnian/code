    public delegate void Winner();
    public event Winner OnWinnerFound;
    ...
    OnWinnerFound(); // Just call your event
    MessageBox.Show("Victory " + label3.Text, "Game Finished", MessageBoxButtons.OK);
                this.Close();
