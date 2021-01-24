    Dictionary<Keys, int> values = new Dictionary<Keys, int>();
    values.Add(Keys.ColorSelection, Convert.ToInt32(Color.Black));
    values.Add(Keys.GenderSelection, Convert.ToInt32(Gender.Male));
    values.Add(Keys.DaySelection, Convert.ToInt32(Day.Wednesday));
    
    foreach (KeyValuePair<Keys, int> kv in values)
    {
        dynamic enumValue = null;
    
        switch (kv.Key)
        {
            case Keys.ColorSelection:
                enumValue = Enum.Parse(typeof(Color), Convert.ToString(kv.Value));
                break;
            
            case Keys.DaySelection:
                enumValue = Enum.Parse(typeof(Day), Convert.ToString(kv.Value));
                break;
    
            case Keys.GenderSelection:
                enumValue = Enum.Parse(typeof(Gender), Convert.ToString(kv.Value));
                break;
        }
    
        Console.WriteLine(String.Format("Enum value: {0}", enumValue));
    }
    
    /* Output:
    Enum value: Black
    Enum value: Male
    Enum value: Wednesday
    */
