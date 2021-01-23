    class A
            {
                public int Id { get; set; }
    
                public string Value { get; set; }
    
                public void Load()
                {
                    var json = @"{Id:1,Value:""Value""}";
                    JsonConvert.PopulateObject(json, this);
                }
            }
