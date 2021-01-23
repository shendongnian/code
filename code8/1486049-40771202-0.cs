    public void ClearTextBoxes(Control control)
        {
            foreach (Control con in control.Controls)
            {
                TextBox box = con as TextBox;
                box?.Clear();
                if (con.HasChildren)
                {
                    ClearTextBoxes(con);
                }
            }
        }
