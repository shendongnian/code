    string ReturnType(Method m) {
        if (m.Type.Name == "IActionResult"){
            foreach (var a in m.Attributes){
                // Checks to see if there is an attribute to match returnType
                if (a.name == "returnType"){
                    // a.Value will be in the basic format "typeof(Project.Namespace.Object)" or "typeof(System.Collections.Generic.List<Project.Namespace.Object>)
                    // so we need to strip out all the unwanted info to get Object type
                    string type = string.Empty;
                    
                    // check to see if it is an list, so we can append "[]" later
                    bool isArray = a.Value.Contains("<");
                    string formattedType = a.Value.Replace("<", "").Replace(">", "").Replace("typeof(", "").Replace(")", "");
                    string[] ar;
                    ar = formattedType.Split('.');
                    type = ar[ar.Length - 1];
                    if (isArray){
                        type += "[]";
                    }
                    // mismatch on bool vs boolean
                    if (type == "bool"){
                        type = "boolean";
                    }
                    return type;
                }
            }
            return "void";
        }
        return m.Type.Name;
    }
