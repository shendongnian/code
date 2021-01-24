       private string _application_role;
       public string application_role 
       { 
           get{
                return JsonConvert.DeserializeObject<string>(_application_role)
             } 
           set{
               _application_role = JsonConvert.SerializeObject(value);
             } 
       }
       
