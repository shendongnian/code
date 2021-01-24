    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        customer = btnEditCustomer1.Text;
        piece = btnPiece.Text;
        material = txtMaterial.Text;
        quantity = Convert.ToInt32(txtQuantity.Text);
        weight = float.Parse(txtWeight.Text);
        if (customer != null && piece != null && material != null)
        {
            AllItems.Add( CreateItem() );
        }
    }
