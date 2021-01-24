    DataTable dt = new DataTable();
    mda.Fill(dt);
     
    var quantity = dt.Columns.Add("quantity", typeof(int));
    quantity.DefaultValue = int.Parse(txtQuantity.Text);
    dt.AsEnumerable().ToList().ForEach(r =>
    {
        r[quantity] = quantity.DefaultValue;
    });
    dgvCart.DataSource = dt;
