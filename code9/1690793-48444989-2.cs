    foreach (PropertyData property in properties){
    foreach (QualifierData q in property.Qualifiers){
       if (property.IsArray){
           if (property.Value != null){
               Type t = property.Value.GetType();
               object o = property.Value;
               dynamic foo = o;
               if (IsPropertyExist(foo, "Length")){
                    string s1 = "";
                    for (int i = 0; i < foo.Length; i++)
                       s1 += "[" +foo[i] +"]";
                    Global.LogMessage("[" + property.Name + "] (" + q.Value + ")  = " + s1 , 1);
            }
