        bool skipSave = false;
        if (prop == null)
        {
           prop = props.Add(customProperty, OlUserPropertyType.olText);
           prop.Value = "foo";
           Debug.WriteLine("added property: foo");
        }
        else
        {
           if(prop.Value != "bar")
           {
              prop.Value = "bar";
              Debug.WriteLine("change property: bar");
           }
           else
              skipSave = true;                        
        }
    
        if(!skipSave)
           mail.Save();
