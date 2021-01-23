    List<string> checked = new List<string>()
    if (check_mon.IsChecked)
    {
       checked.Add("Mon");
    }
    if (checked.Contains(passArg))
    {
       MessageBox.Show("RAN");
    }
