    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Mammals") //You can also do index e.g. comboBox1.SelectedIndex == 0
            {
                comboBox2.DataSource = mammalList;
            }
            else
            {
                comboBox2.DataSource = reptileList;
            }
        }
