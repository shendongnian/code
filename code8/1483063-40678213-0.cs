    private void button1_Click(object sender, EventArgs e)
    {
        if(Double.TryParse (txtVisina.Text, out v) &&
             Double.TryParse (txtTezina.Text, out t)) {
            r = t / (v * v);
            txtBmiRez.Text = String.Format("{0:f}", r);
        } else {
            // Handle failure to parse
            MessageBox.Show("Failed to parse text to number.");
        }
    }
