    private void Dg_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        var textCol = e.Column as DataGridTextColumn;
        if (textCol == null)
            return;
        var binding = textCol.Binding as Binding;
        if (binding == null)
            return;
        binding.Path = new PropertyPath("[" + binding.Path.Path + "]");
    }
