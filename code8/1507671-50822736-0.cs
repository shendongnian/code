      private void Tb_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var tbx = e.OriginalSource as TextBox;
            string dd = tbx?.Text;
            if (tbx == null || string.IsNullOrEmpty(dd)) return;
            var tt = dd.Select(r => r.ToString()).ToList();
            var myregex = ".1234567890".Select(r => r.ToString()).ToList();
            var ss = new List<string>();
            tt.ForEach(o =>
            {
                if (ss.Contains(".") && o != "." || !ss.Contains("."))
                {
                    if (myregex.Contains(o))
                        ss.Add(o);
                    if (ss.FirstOrDefault() == ".")
                    {
                        ss[0] = "0";
                        ss.Add(".");
                    }
                    if (ss.Count == 2 && ss.FirstOrDefault() == "0" && o != ".")
                    {
                        ss[1] = ".";
                        ss.Add(o);
                    }
                }
            }
            );
            var sbc = new StringBuilder();
            ss.ForEach(u => sbc.Append(u));
            tb.Text = sbc.ToString();
            tb.CaretIndex = tb.Text.Length;
        }
 
