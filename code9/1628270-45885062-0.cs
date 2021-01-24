    while ((line_of_text = file.ReadLine()) != null)
    {
        // Stuff
        full_name name = new full_name();
        if (pos > -1)
        {
            ...
            name.f_name = "NOT";
            name.l_name = "FOUND";
        }
        
        // Other if statements
        if (!dict.ContainsKey(user_id))
        {
            dict.Add(user_id, name);
        }
    }
