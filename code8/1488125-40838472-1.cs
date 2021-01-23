    private void dllby_SelectedIndexChanged(object sender, EventArgs e)
    {
            Type myType = dllby.SelectedItem.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                if(prop.Name=="value")
                    textBox1.Text = prop.GetValue(dllby.SelectedItem, null).ToString();
            }
    }
