    public static class Extensions
    {
        public static Color cb_colorear(this Form form, string cbName, string label)
        {
            Control[] ctrl = form.Controls.Find(cbName, true);
            CheckBox cb = ctrl[0] as CheckBox;
    
            Control[] ctrl2 = form.Controls.Find(label, true);
            Label lbl = ctrl2[0] as Label;
    
            if (!cb.Checked)
            {
                lbl.BackColor = Color.Red;
            }
            else
            {
                lbl.BackColor = Color.LawnGreen;
            }
        }
    }
