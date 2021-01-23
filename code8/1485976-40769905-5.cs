    public IActionResult IndexJson()
        {
            List<List<SampleClass>> data =new List<List<SampleClass>>();
    
                SampleClass item1 = new SampleClass()
                {
                    Name = "Matt",
                    Age = 24,
                    HairColor = "brown"
                };
                SampleClass item2= new SampleClass()
                {
                    Name = "John",
                    Age = 55,
                    HairColor = "no hair"
                };
    
                List<SampleClass> sanpleSampleClasses1= new List<SampleClass>();
                List<SampleClass> sanpleSampleClasse2 = new List<SampleClass>();
    
                sanpleSampleClasses1.Add(item1);
                sanpleSampleClasse2.Add(item2);
    
                data.Add(sanpleSampleClasse2);
                data.Add(sanpleSampleClasses1);
    
               var json =  JsonConvert.SerializeObject(new {data= data });
              return Content(json, "application/json");
        }
