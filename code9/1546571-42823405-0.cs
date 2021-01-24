            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    TextBox tb = c as TextBox;
                    tb.GotFocus += delegate { tb.SelectAll(); };
                }
            }
