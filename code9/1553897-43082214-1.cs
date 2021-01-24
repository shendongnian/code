    private void dt_ValueChanged(object sender, EventArgs e)
    {
                String dtnow = DateTime.Now.ToString("yyyy-MM-dd");
                if (DateTime.Parse(dt.Text) < DateTime.Parse(dtnow))
                {
                    MessageBox.Show("Invalid Date");
                    //Return the date now
                    dt.Text = DateTime.Parse(dtnow).ToString("yyyy-MM-dd");
                }
    }
