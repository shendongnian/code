    var names = fullName.Split(' ')
                        .Where(name => string.IsNullOrWhiteSpace(name) == false)
                        .Select((Name, Index) => new { Name, Index })
                        .ToDictionary(item => item.Index, item => item.Name);
    names.TryGetValue(0, out string firstName);
    names.TryGetValue(1, out string middleName);
    if (names.TryGetValue(2, out string lastName) == false)
    {
        lastName = middleName;
        middleName = null;
    }
    var result = new StringBuilder();
    result.AppendLine("First name: ${firstName}");
    result.AppendLine("Middle name: ${middleName}");
    result.AppendLine("Last name: ${lastName}");
    MessageBox.Show(result.ToString());
