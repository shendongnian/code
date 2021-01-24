    private void propertyGrid1_SelectedObjectsChanged(object sender, EventArgs e)
    {
        var grid = propertyGrid1.Controls.Cast<Control>()
            .Where(x => x.GetType().Name == "PropertyGridView").FirstOrDefault();
        var edit = grid.Controls.Cast<Control>()
            .Where(x => x.GetType().Name == "GridViewEdit").FirstOrDefault();
        edit.Click -= edit_Click;
        edit.Click += edit_Click;
    }
    private void edit_Click(object sender, EventArgs e)
    {
        var item = this.propertyGrid1.SelectedGridItem;
        if (item.GetType().Name == "PropertyDescriptorGridEntry")
        {
            var method = item.GetType().GetMethod("EditPropertyValue",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);
            var grid = propertyGrid1.Controls.Cast<Control>()
                .Where(x => x.GetType().Name == "PropertyGridView").FirstOrDefault();
            method.Invoke(item, new object[] { grid });
        }
    }
