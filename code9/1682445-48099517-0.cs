    StringBuilder sHTML = new StringBuilder();
    foreach (BuildersFirstSource item in lstBuilders)
    {
        // Modify the following line so that you are adding the
        // correct string from item
        sHTML.Append(item.ToString());
        sHTML.Append(Environment.NewLine);
    }
    txtPriceOne.Text = sHTML.ToString();
