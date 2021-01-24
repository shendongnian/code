    int count = 0;
    Int32.TryParse(txt_hafta.Text, out count);
    List<int> dataSource = new List<int>();
    for (int i = 1; i <= count; i++)
    {
        dataSource.Add(i);
    }
    hafta.DataSource = dataSource;
    hafta.DropDownStyle = ComboBoxStyle.DropDownList
