    var boxes = columnpanel1.Controls.OfType<CheckBox>().Where(c=>c.Checked).ToList();
     foreach(var chk in boxes )
            {
              string s = chk.Text;
            }
