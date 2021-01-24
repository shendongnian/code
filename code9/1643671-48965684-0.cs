            var emp = new Employee { Name = "Mike" };
            var employees = new List<Employee>();
            employees.Add(emp);
            var engine = new Engine();
            engine.SetValue("employees", employees);
            // how to get the value "Mike" out of the engine?
            JsValue name = engine.Execute("employees[0].Name").GetCompletionValue();
            System.Console.WriteLine(name.ToString());//This should return Mike
