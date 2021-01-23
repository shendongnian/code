        foreach(Panel pnl in Controls.OfType<Panel>())
        {
            foreach(TextBox tb in pnl.Controls.OfType<TextBox>())
            {
                if(string.IsNullOrEmpty(tb.Text.Trim()))
                {
                    MessageBox.Show("Text box can't be empty");
                }
            }
        }
