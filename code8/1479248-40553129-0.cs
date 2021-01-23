    private void pClick(object sender, EventArgs e)
    {
        Panel panel = (sender as Panel);
        if (panel.BackColor == Color.Green) {
            foreach(var control in mainPanel.Controls) {
                if (control is Panel) {
                    Panel innerPanel = control as Panel;
                    innerPanel.BackColor = Color.Red;
                }
            }
        } else if (panel.BackColor == Color.Red) {
            foreach(var control in mainPanel.Controls) {
                if (control is Panel) {
                    Panel innerPanel = control as Panel;
                    innerPanel.BackColor = Color.Green;
                }
            }
        }
    }
