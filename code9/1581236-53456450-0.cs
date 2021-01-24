     class MyClass
      {
        public int Id { get; set; }// Existing property
        public List<dynamic> Information { get; set; } 
        // Added above property to handle new properties which will come dynamically  
      }
           //-------- While Implementing ----
            MyClass obj = new MyClass();
            obj.Id = 1111; // Existing Property
            obj.Information = new List<dynamic>();
            obj.Information.Add(new ExpandoObject());
            obj.Information[0].Name= "Gyan"; // New Property 
            obj.Information[0].Age = 22; // New Property 
