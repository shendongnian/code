    [Route("Save")]
    [HttpPost]
    public string Save(JObject EmpData)
    {
    dynamic json = EmpData;
    A1 Emp=json.Emp.ToObject<A1>();
    List<A2> EmpMarks=json.ToObject<List<A2>>();
    }
