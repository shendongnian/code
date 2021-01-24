       public partial class entity
       {
          public int ID { get; set; }
          public string JSONArray { get; set; }
          public List<JSONArray> JSONArrayList
        {
            get { 
            if (Tags != null)  
               return JsonConvert.DeserializeObject<List<JSONArray>>(JSONArray); 
            else 
                return null; 
        }
            set 
             { 
               if (value != null) 
               JSONArray = JsonConvert.SerializeObject(value);
             }
        } 
      }
  
      public class JSONArray
        {
            public string Name { get; set; }
            public string LastName { get; set; }
        }
