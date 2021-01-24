    if (txbStatus.Text.Length > MAGIC_NUMBER) 
    {
        txbStatus.Text = sp.ReadExisting(); //Replace existing content
    }
    else
    {
        txbStatus.Text += sp.ReadExisting(); //Append content
    }
