    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = fncGetSpecies(comboBox1.SelectedIndex);
        }
        private string[] fncGetSpecies(int intIndex)
        {
            //This will return if selected item is 0 which is Mammals or 1 if the selected item is Reptiles.
            return intIndex == 0 ? mammalList : reptileList;
        }
