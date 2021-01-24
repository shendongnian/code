    private void ColorRow(DataGrid dg)
    {
        for (int i = 0; i < dg.Items.Count; i++)
        {
            DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(i);
            if (row != null)
            {
                int index = row.GetIndex();
                if (index % 2 == 0)
                {
                    SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(100, 255, 104, 0));
                    row.Background = brush;
                }
                else
                {
                    SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(100, 255, 232, 0));
                    row.Background = brush;
                }
            }
        }
    }
