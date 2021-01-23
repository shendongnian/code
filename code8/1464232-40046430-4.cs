    private void PrenomNomUtilisateur()
    {
    	string _NomUtilisateur = Session["NomUtilisateur"];
    	string _MotDePasse = Session["MotDePasse"];
    	SqlConnection oConnexion = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["SaisieHeuresConnectionString"]));
    	SqlCommand oCommand = new SqlCommand("SELECT * FROM Utilisateurs WHERE NomUtilisateur='" + _NomUtilisateur + "'", oConnexion);
    
    	try
    	{
    		// Ouverture de la connexion et exécution de la requête
    		oConnexion.Open();
    		SqlDataReader drUtilisateur = oCommand.ExecuteReader();
    		// Parcours de la liste des utilisateurs
    		while (drUtilisateur.Read())
    		{
    			if (drUtilisateur["MotDePasse"].ToString() == _MotDePasse)
    			{
    				PrenomNom = drUtilisateur["PrenomNom"].ToString();
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine("Exception : " + ex.Message);
    	}
    	finally
    	{
    		oConnexion.Close();
    	}
    }
