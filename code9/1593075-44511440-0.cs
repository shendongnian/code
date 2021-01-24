        private void FontsMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog.
            DialogResult result = fontDialog1.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                // Get Font.
                Font = fontDialog1.Font;
            }
        }
