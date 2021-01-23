    private void button_Clicked(object sender, RoutedEventArgs e)
    {
        List<string> lstContent = new List<string>();
        foreach (GridViewColumn gvc in gvMyGridView.Children)
        {
            foreach (CellTemplate ct in gvc)
            {
                foreach (Checkbox cb in ct)
                {
                    if (cb.IsChecked == true)
                        lstContent.Add(/*Corresponding Text Box*/.Content.ToString();
                }
            }
        }
    }
