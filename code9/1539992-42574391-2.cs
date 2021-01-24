    foreach (var item in efList)
    {
        foreach (var option in item.Options)
        {
            stringBuilder.Append(String.Format("{0}={1}|", item.Name, option.Value));
        }
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.AppendLine();
    }
