        private void button2_Click(object sender, EventArgs e)
        {
            List<CheckBox> CheckedBoxes = new List<CheckBox>();
            foreach (CheckBox cb in tabPage1.Controls.OfType<CheckBox>())
            {
                if (cb.Checked)
                {
                    CheckedBoxes.Add(cb);    
                }
            }
            foreach (CheckBox cb in CheckedBoxes)
            {
                string cbName = cb.Name;
                cb.Dispose();
                // ... probably more code in here to find the other controls
                // ... in the "row" based on "cbName"
            }
        }
