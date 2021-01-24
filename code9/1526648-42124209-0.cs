    public IActionResult RegisterUser(JObject obj)
    {
        RegisterUsers user = new RegisterUsers();
        user = JsonConvert.DeserializeObject<RegisterUsers>(((JProperty)obj.First).Name);
        var temp = DataAccessLayer.RegisterUser(user.Username, user.Password, user.Firstname, user.Lastname, user.Email, null, null);
        JObject jobj = new JObject();
        jobj.Add("output", temp.ToString());
    
        return Ok(jobj);
    }
