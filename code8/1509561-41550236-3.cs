    private void btnPayment_Click(object sender, EventArgs e)
    {
        holDer = double.Parse(tbPayment.Text) - double.Parse(lblTotalPrice.Text);
        MessageBox.Show("Change: " + holDer.ToString());
    }
