    var image = product.Images.FirstOrDefault();
    if (image != null)
    {
        row.Cells.Add(new TableCell { Text = "<img src='"+ image.PathImg +"'/>" });
    }
