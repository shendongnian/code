    private void LoadRolesToStackPanel()
    {
        try
        {
            var roles = RolesController.Instance.SelectAll();
            if (roles.Count > 0)
            {
                foreach (Role r in roles)
                {
                    CheckBox cb = new CheckBox();
                    cb.Tag = r;
                    cb.Content = r.Title.ToString();
                    cb.FontSize = 15;
                    stackRole.Children.Add(cb);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    foreach (CheckBox box in selectedBoxes)
    {
        Role r = (Role)box.Tag;
        //Here we get Id and every other Property that Role had
        var x = r.Id;
    }
