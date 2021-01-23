    public enum MyEnum
            {
                Admin = 10,
                Manager = 20,
                Peon = 30
            }
    
    public static int ConvertFromPosition(string pos)
    {
           switch(pos.ToLower().Trim())
             {
               case "admin": return MyEnum.Admin; break;
               case "manager": return MyEnum.Manager; break;
               case "peon": return MyEnum.Peon; break;
               default:
                    Throw new ApplicationException("Position " + pos + " is not a valid position.");
             }
     
    }
