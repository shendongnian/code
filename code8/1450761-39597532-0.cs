            foreach(GroupBox gb in Controls.OfType<GroupBox>())
            {
                foreach(TextBox tb in gb.Controls.OfType<TextBox>())
                {
                    int A1 = 0;
                    int.TryParse(tb.Text, out A1);
                    TOTAL += A1;   //defined outside of the method
                }
            }
