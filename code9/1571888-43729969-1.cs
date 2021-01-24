    public YourEntity[] Search(string name = "", int? age = null, bool? isActive = null)
    {
        string query = "SELECT * FROM YourEntities";
        List<string> whereConditions = new List<string>();
        if (!string.IsNullOrWhiteSpace(name))
        {
            whereConditions.Add($"name LIKE '%{name}%'");
        }
        if (age.HasValue)
        {
            whereConditions.Add($"age = {age.Value}");
        }
        if (isActive.HasValue)
        {
            whereConditions.Add($"isActive = {isActive.Value:D}");
        }
        if (whereConditions.Any())
        {
           query += "WHERE " + string.Join(" AND ", whereConditions);
        }
        return someSqlExecutorAndProcessor(query);
    }
