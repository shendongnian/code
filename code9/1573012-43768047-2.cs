    for (int i = 0; i < e.Row.Cells.Count; i++)
    {
        if (i % 2 == 1)
        {
            Image image = new Image();
            image.ImageUrl = @"/image.jpg";
            e.Row.Cells[i].Controls.Add(image);
        }
    }
