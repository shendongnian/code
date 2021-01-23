    StringBuilder builder = new StringBuilder();
    for(int i = 0; i< result.Count;i++)
    {
         builder.AppendLine(result[i]);
    }
    textbox.Text = builder.ToString();
