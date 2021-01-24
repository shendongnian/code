    List<Student> list = new List<Student>();
    foreach (BigQueryRow row in results.GetRows())
    {
        Student s=new Student();
        s.id = Convert.ToString(row["id"]);
        s.name=  Convert.ToString(row["name"]);
        list.Add(s);
    }
    var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(list);
    
