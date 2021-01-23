    public IActionResult IndexJson()
        {
            List<List<string>> data = new List<List<string>>();
            data.Add(new List<string>(new string[] {"test1", "test2"}));
            data.Add(new List<string>(new string[] {"test3", "test4"}));
            var json = JsonConvert.SerializeObject(new {data = data});
            return Content(json, "application/json");
        }
