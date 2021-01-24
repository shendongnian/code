    foreach (PropertyData property in properties){
    foreach (QualifierData q in property.Qualifiers){
       if (property.IsArray) {
            foreach (((q.Value).GetType()) x in ((q.Value).GetType())property.Value)
            {
                Global.LogMessage("[" + property.Name + "] = '" + x + "'", 1)
            }
       }
    }
    }
