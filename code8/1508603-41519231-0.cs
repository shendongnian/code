    class obj
     {
       public string name {get ; set; }
       public string pic_large {get ; set; }
       public id {get ; set; }
     }
    using System.Web.Script.Serialization;
    .
    .
    var obj = new JavaScriptSerializer().Deserialize<obj>(jsonString);
 
