    foreach (var item in MColumnsListXaml.Items.OfType<MandatoryColumns>())
    {
        MessageBox.Show(item.MColumnName);
        MessageBox.Show(item.MColumnName2);
    }
