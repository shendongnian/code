    Dictionary<string, List<string>> dictionary_1 = new Dictionary<string, List<string>> { };
    Dictionary<string, List<string>> dictionary_2 = new Dictionary<string, List<string>> { };
    // Fill those dictionaries...
    // Check for non existing things in dictionary 2 but existing in 1
    foreach (KeyValuePair<String, List<String>> _element in dictionary_1)
    {
        List<String> _valuesFrom2;
        // Check if table exist
        if (dictionary_2.TryGetValue(_element.Key, out _valuesFrom2))
        {
            //Check if column exist
            foreach (String _value in _element.Value)
            {
                if (!_valuesFrom2.Contains(_value))
                {
                    Console.WriteLine($"Dictionary 2, table {_element.Key} does not contain {_value}");
                }
            }
        }
        else
        {
            Console.WriteLine($"Dictionnary 2 does not contain : {_element.Key}");
        }
    }
    
