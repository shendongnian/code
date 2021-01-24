    public static void getObj(object i_obj)
    {
        Type objType = i_obj.GetType();
        FieldInfo[] objField = objType.GetFields();
        foreach (FieldInfo member in objField)
        {
            Type memberType = member.FieldType;
            object memberValue = member.GetValue(i_obj); // <---
            if (memberValue == null)
            {
                Console.WriteLine(member.Name + " : null");
            }
            else if(memberType.IsClass)
            {                    
                getObj(memberValue); // <---
            }
            else
            {
                Console.WriteLine(member.Name + " : " + memberValue);
            }
        }
    }
