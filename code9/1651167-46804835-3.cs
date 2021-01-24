    using System.Web.Script.Serialization;
    public static bool IsJsonLengthValid(object myObj) {
        try {
             var jsonValue = new JavaScriptSerializer().Serialize(myObj);
        } catch(InvalidOperationException e) {
             return false;
        } 
        return true;
    }
    
