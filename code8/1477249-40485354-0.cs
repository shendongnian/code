    void ValueChanged(object sender, EventArgs e)
        {
            string temp_id = ((NumericUpDown)sender).Name.Remove(0, 14);
            if(temp_id[0]=='0')
            {
                temp_id = temp_id.Remove(0, 1);
            }
            int id = Int32.Parse(temp_id);
            decimal v1, v2;
            var numericUpDown1 = this.panel1.Controls["numericUpDown" + (100+id).ToString()] as NumericUpDown;
            var numericUpDown2 = this.panel1.Controls["numericUpDown" + (200+id).ToString()] as NumericUpDown;
            var CurrentTextBox = this.panel1.Controls["Text" + (100+id).ToString()] as TextBox;
            if (numericUpDown1 != null && numericUpDown2 != null)
            {
                v1 = numericUpDown1.Value;
                v2 = numericUpDown2.Value;
                CurrentTextBox.Text = (v1 * v2).ToString();
            };
