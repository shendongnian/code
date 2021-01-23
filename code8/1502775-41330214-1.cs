    var enumValues = Enum.GetValues(typeof(SomeModeType)).Cast<object>()
        .Select(x => new { Value = x, Name = x.ToString() }).ToList();
    enumValues.ForEach(x =>
    {
        var radio = new RadioButton() { Text = x.Name, Tag = x.Value };
        var binding = radio.DataBindings.Add("Checked", dataSource,
            "Mode", true, DataSourceUpdateMode.OnPropertyChanged);
        binding.Format += (obj, ea) =>
        { ea.Value = ((Binding)obj).Control.Tag.Equals(ea.Value); };
        binding.Parse += (obj, ea) =>
        { if ((bool)ea.Value == true) ea.Value = ((Binding)obj).Control.Tag; };
        flowLayoutPanel1.Controls.Add(radio);
    });
