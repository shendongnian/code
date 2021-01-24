    private void PreferenceChange(object sender, Preference.PreferenceChangeEventArgs e)
    {
        var selections = e.NewValue as IEnumerable;
        if (selections != null)
        {
            foreach (var selection in selections)
            {
                Console.WriteLine(selection);
            }
        }
    }
