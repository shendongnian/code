    public List<HelpDesk> getOplossing(string probleem)
    {
        ...
        
        cmd.Parameters.Add(new MySqlParameter("@probleem", probleem));
        ...
    }
