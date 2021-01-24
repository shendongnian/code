    if (txtbox_mobileno.Text.Length == 3)
    {
        List<string> numbers;
        if (_buckets.TryGetValue(txtbox_mobileno.Text, out numbers)
        {
            var ac = new AutoCompleteStringCollection();
            ac.AddRange(numbers.ToArray());
            txtbox_mobileno.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtbox_mobileno.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtbox_mobileno.AutoCompleteCustomSource = ac;
        }
    }
