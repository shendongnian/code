        private void hand_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "OK", "message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        private void button2_Click_2(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "OK", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }
        private void btninformation_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "Data saved successfully. \n Thank You.", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
