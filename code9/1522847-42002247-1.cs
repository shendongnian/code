    foreach (Control c in tabPage4.Controls)
    {
        if (c is GroupBox)
        {
            foreach (Control d in c.Controls)
            {
                var e = d as CheckBox;
                if (e != null)
                {
                    MessageBox.Show(d.Name + "  " + e.Checked);
                    checkedList.Add(d.Name, e.Checked.ToString());
                }
            }
        }
    }
