    var filesByCheckbox = new Dictionary<CheckBox, string> {
        { checkbox1, filename1 },
        { checkbox2, filename2 },
        { checkbox3, filename3 }
    };
    foreach (var kvp in filesByCheckbox)
    {
        if (kvp.Key.IsChecked)
        {
            Code(kvp.Value);
        }
    }
