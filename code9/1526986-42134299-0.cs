     private void checkBox3_CheckedChanged(object sender, EventArgs e) {
       bool isRetail = checkBox3.Checked && comboBox1.SelectedText == "Retail";
       bool isStandalone = checkBox3.Checked && comboBox1.SelectedText == "Standalone";
       checkBox2.Enabled = isRetail;
       checkBox1.Enabled = !(isRetail || isStandalone);
       checkBox1.BackColor = checkBox1.Enabled ? default(Color) : Color.Gray;
       checkBox2.BackColor = checkBox2.Enabled ? default(Color) : Color.Gray;
     }
   
