    public void btnInsert_Click(object sender, EventArgs e)
    {
        var product = new Product();
        product.ID = Convert.ToInt32(txtId.Text);
        product.Name = txtName.Text;
        product.Category = txtCategory.Text;
        product.Price = Convert.ToDouble(txtPrice.Text);
        products.Add(product);
        dataGridView1.DataSource = products;
    }
