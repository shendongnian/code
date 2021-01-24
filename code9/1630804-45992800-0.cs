    var binding = 
        new Binding("DataSource", txt_hafta, "Text", true, DataSourceUpdateMode.Never);
    binding.Format += (sender, args) =>
    {
        int.TryParse(args.Value.ToString(), out int maxNumber);
        args.Value = Enumerable.Range(1, maxNumber).ToList();
    };
    cmb_hafta.DataBindings.Add(binding);
