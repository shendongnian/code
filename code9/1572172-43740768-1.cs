    static public Data loadData()
    {
        Data database = new Data();
        myConnexion.Open();
        /// <summary>
        ///     Loading of the categories
        /// </summary> 
        MySqlCommand command = new MySqlCommand("getCategory", myConnexion);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        using (var cursor = command.ExecuteReader())
        {
            while (cursor.Read())
            {
                int id = Convert.ToInt32(cursor["id"]);
                string categoryName = Convert.ToString(cursor["name"]);
                Category category = new Category(id, categoryName);
                database.addCategory(category);
            }
        }
    
        /// <summary>
        ///     Loading of the projects
        /// </summary>
        command = new MySqlCommand("getProject", myConnexion);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        using(var cursor = command.ExecuteReader())
        {
            while (cursor.Read())
            {
                int idProject = Convert.ToInt32(cursor["id"]);
                string name = Convert.ToString(cursor["name"]);
                int idCategory = Convert.ToInt32(cursor["idCategory"]);
                Category category = database.getCategories()[idCategory];
                Project project = new Project(idProject, name, category);
                Link.addProject(project.getName(), category);
            }
        }
        myConnexion.Close();
        return database;
    }
