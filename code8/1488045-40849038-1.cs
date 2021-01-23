    int temp = 0;
    StringBuilder sb = new StringBuilder();
    if (CasAChk.Checked && Int32.TryParse(CasA.Text, out temp))
    {
        sb.Append(string.Format("[CasA] = '{0}'", temp));
    }
    if (CasBChk.Checked && Int32.TryParse(CasB.Text, out temp))
    {
        if (sb.Length > 0)
        {
            sb.Append(" OR ");
        }
        sb.Append(string.Format("[CasB] = '{0}'", temp));
    }
    view.RowFilter = sb.ToString();
    ViewNectarGV.DataSource = view;
