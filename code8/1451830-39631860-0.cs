     private void listBox_Click(object sender, EventArgs e)
        {
           if (listBox.SelectedIndex != -1)
            {
                var colorSel = listBox.SelectedItem.ToString();
                switch (colorSel)
                {
                    case "Yellow":
                        this.BackColor = Color.Yellow;
                        break;
                    //othercolors
                }
            }
        }
