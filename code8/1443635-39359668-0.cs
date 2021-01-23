    private void labelChoosenType_Click(object sender, EventArgs e)
    {
        Label clickedLabel = sender as Label;
        if (clickedLabel != null)
        {
            MessageBox.Show(clickedLabel.Text);
        }
        else
        {
            // clickedLabel is not a Label or is null, do something else
        }
    }
