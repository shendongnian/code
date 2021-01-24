    // Turn IActionResult into void
    string ReturnType(Method objMethod) 
    {
        if(objMethod.Type.Name == "IActionResult")
        {
                if((objMethod.Parameters.Where(x => !x.Type.IsPrimitive).FirstOrDefault() != null))
                {
                    return objMethod.Parameters.Where(x => !x.Type.IsPrimitive).FirstOrDefault().Name;
                }
                else
                {
                    return "void";
                }
        } 
        else
        {
                return objMethod.Type.Name;
        }
    }
