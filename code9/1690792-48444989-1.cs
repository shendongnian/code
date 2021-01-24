    foreach (PropertyData property in properties){
    foreach (QualifierData q in property.Qualifiers){
       if (property.IsArray) {
          Type t = property.Value.GetType();
          object o = property.Value;
          // HERE I dont know how to cast the object o to the type t.               
          for (int i = 0; i < o.Count; i++)
             Global.LogMessage("[" + property.Name + "] = '" + x + "'", 1)
            
       }
    }
    }
