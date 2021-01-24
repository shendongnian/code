        public string JSONTest()
        {
    
            List<Class1> colors = new List<Class1>();
            colors.Add(new Class1() { ID = 1, Name = "Black" });
            colors.Add(new Class1() { ID = 1, Name = "Red" });
            colors.Add(new Class1() { ID = 1, Name = "Blue", Code = "blx" });
    
            return JsonConvert.SerializeObject(new Rootobject { Property1 = colors.ToArray() });
        }
