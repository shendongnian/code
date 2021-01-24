    bool ProductIDExist = false;
    foreach (DataGridViewRow ItemRow in DGV_INVOICE.Rows)
    {
        //Check if the product Id exists with the same Price
        ProductIDExist |= Convert.ToString(ItemRow.Cells[2].Value) == TB_Product_ID.Text
        
        if (productIDExist)
        {
            break;
        }
    }
    if (productIDExist)
    {
        //increase quantity by 1
    }
    else
    {
        //add a new row
    }
