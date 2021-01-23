     public List<TextBox> GetTextbox(Form f)
        {
            List<TextBox> txtboxlist = new List<TextBox>();
            foreach (var Control in f.Controls)
            {
                if (Control.GetType() == typeof(TextBox))
                {
                    txtboxlist.Add((TextBox)Control);
                }
            }
            return txtboxlist;
        } 
