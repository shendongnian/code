    var fc= Application.OpenForms.OfType<FilterControl>().SingleOrDefault();
    while (rd.Read())
                {
                    fc.listBoxColumnHeaders.Items.Add(rd["AsHeading"].ToString());
                    MessageBox.Show(rd["AsHeading"].ToString()); 
                }
