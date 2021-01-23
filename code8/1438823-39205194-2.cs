    SqlParameter unitsParam = command.Parameters.AddWithValue("@ProductImage", SqlDbType.Image);
    if (product.ProductImage == null)
    {
        unitsParam.Value = DBNull.Value;
    }
    else
    {
        unitsParam.Value = product.ProductImage
    }
