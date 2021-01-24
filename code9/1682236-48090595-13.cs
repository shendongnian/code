    public void btnInsert_Click(object sender, EventArgs e)
    {
        var id = Convert.ToInt32(txtId.Text);
        var objProduct = products.FirstOrDefault(product => product.ID == id);
        if (objProduct == null)
        {
            objProduct = new Product();
            objProduct.ID = id;
            objProduct.Name = txtName.Text;
            objProduct.Category = txtCategory.Text;
            objProduct.Price = Convert.ToDouble(txtPrice.Text);
            products.Add(objProduct);
        }
        else
        {
            objProduct.Name = txtName.Text;
            objProduct.Category = txtCategory.Text;
            objProduct.Price = Convert.ToDouble(txtPrice.Text);
        }
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = products;
    }
