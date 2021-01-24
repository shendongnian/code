    private void OnButton1Click(object sender, EventArgs e)
    {
        FilterForm filter = new FilterForm(txtFieldName.Text,txtValues.Text);
        if (filter.ShowDialog() == DialogResult.OK)
        {
            int a = filter.a; //Here you can able to access public property from Filter form.
        }
    }
