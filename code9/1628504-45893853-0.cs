    Double myDouble;
    Double defaultValue = 0;
    var value = Console.ReadLine();
    
           if (!double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out myDouble ) &&
                // Then try in US english
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out myDouble ) &&
                // Then in neutral language
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out myDouble ))
            {
                myDouble = defaultValue;
            }
    Console.WriteLine(myDouble);
  
  
