    public static List<String> LoadPetsBySanctuary2(int sID)
    {
        using(var myConnection = GetConnection())
        {
            return myConnection.Query<string>(
                "SELECT  Name  FROM pet WHERE sanID = @sID",
                new { sID }).AsList();
        }
    }
