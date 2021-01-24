            List<Myclass> model = new List<Myclass>();
            model.Add(new Myclass() { Id = 1, Name = "Name1", Age = 50 });
            model.Add(new Myclass() { Id = 2, Name = "Name2", Age = 51 });
            model.Add(new Myclass() { Id = 3, Name = "Name3", Age = 52 });
            string json = JsonConvert.SerializeObject(model);
            //If you want to replace { with [ and } with ]
            json = json.Replace("{", "[").Replace("}", "]");
            //you can use this workaround to get rid of property names
            string propHeader = "\"{0}\":";
            json= json.Replace(string.Format(propHeader, "Id"), "")
                .Replace(string.Format(propHeader, "Name"),"")
                .Replace(string.Format(propHeader, "Age"), "");
            Console.WriteLine(json);
