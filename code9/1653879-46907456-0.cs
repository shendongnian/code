    private void cbForms_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cbForms != null)
        {
            ComboBoxItem item = cbForms.SelectedItem as ComboBoxItem;
            if (item != null && item.Content != null)
            {
                string text = item.Content.ToString();
                switch (text)
                {
                    case "Polygon":
                        {
                            commandText = "SELECT f.bezeichnung, t.X, t.Y, t.id FROM figure05 f, TABLE(SDO_UTIL.GETVERTICES(f.shape)) t";
                            lblAnz.Content = anzPolygon.ToString();
                            break;
                        }
                }
            }
        }
    }
