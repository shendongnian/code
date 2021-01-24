    public MyClass RetrieveObj(string id, myEnum callType)
    {
         MyClass obj = null;
         foreach(var element in ListOfStoreObjects)
         {
             if( element.ID == id && element.CallType == callType)
             {
                 obj = element;
                 break;
             }
         }
         ListOfStoreObjects.Remove(obj);
         return obj;
    }
