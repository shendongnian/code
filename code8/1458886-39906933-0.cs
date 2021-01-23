     /* Previous way of doing it which work for me on a previous project but not 
    working anymore
	*/
    Project proj = Project.OpenProject(fixed_settings.Default.PROJECT_ISPAC);
    
    // New way by creating the project on the fly
                //Test creation project
                Project proj = Project.CreateProject();
                ConnectionManagerItem connectionManagerItem_meta =   proj.ConnectionManagerItems.Add("OLEDB", "META.conmgr");
                connectionManagerItem_meta.ConnectionManager.Name = "META";
                connectionManagerItem_meta.ConnectionManager.ConnectionString = "Data Source=" + fixed_settings.Default.server_meta + ";Initial Catalog=" + fixed_settings.Default.server_meta + ";Provider=SQLNCLI11.1;Integrated Security=SSPI;Auto Translate=False;";
    
                ConnectionManagerItem connectionManagerItem_stg = proj.ConnectionManagerItems.Add("OLEDB", "STG.conmgr");
                connectionManagerItem_stg.ConnectionManager.Name = "STG";
                connectionManagerItem_stg.ConnectionManager.ConnectionString = "Data Source = " + fixed_settings.Default.server_stg + "; Initial Catalog = " + fixed_settings.Default.database_stg + "; Provider = SQLNCLI11.1; Integrated Security = SSPI; Auto Translate = False;";
    
                ConnectionManagerItem connectionManagerItem_hstg = proj.ConnectionManagerItems.Add("OLEDB", "HSTG.conmgr");
                connectionManagerItem_hstg.ConnectionManager.Name = "HSTG";
                connectionManagerItem_hstg.ConnectionManager.ConnectionString = "Data Source=" + fixed_settings.Default.server_hstg + ";Initial Catalog=" + fixed_settings.Default.database_hstg + ";Provider=SQLNCLI11.1;Integrated Security=SSPI;Auto Translate=False;";
