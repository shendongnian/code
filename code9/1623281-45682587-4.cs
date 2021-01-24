    var cache = new Dictionary<string, UserForm>();
    UserForm GetOrCreateForm(string name)
    {
        UserForm f;
        if (!cache.TryGetValue(name, out f))
        {
            f = new UserForm { Name = name };
            cache.Add(name, f); 
        }
        return f;         
    }
    var myForm = GetOrCreateForm("SomeUniqueName");
    myForm.Show();
