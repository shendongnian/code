    for (int i = 0; i < data.data.Length; i++)
    {
        ws.Cells[0, i].Value = data.data[i].name;
        Type type;
        try
        {
            type = Type.GetType((string)data.data[i].type);
        }
        catch (Exception e)
        {
            continue;
        }
        for (int j = 0; j < data.data[i].data.Count; j++)
        {
            ws.Cells[j + 1, i].Value = Convert.ChangeType(data.data[i].data[j], type);
        }
    }
