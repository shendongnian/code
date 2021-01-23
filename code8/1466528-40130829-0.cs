    using System.Web.Script.Serialization;
    List<Object> list = new List<Object>();
    
    JavaScriptSerializer jss = new JavaScriptSerializer();
    
    string res = jss.Serialize(list);
