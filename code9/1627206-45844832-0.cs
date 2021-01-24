	var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
	var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
	connectionStringsSection.ConnectionStrings["DbStatisticsEntities"].ConnectionString =
		"metadata=res://*/Models.DbStatisticsModel.csdl|res://*/Models.DbStatisticsModel.ssdl|res://*/Models.DbStatisticsModel.msl;provider=System.Data.SQLite.EF6;provider connection string='data source=" + this.DBFileName + "'";
	connectionStringsSection.ConnectionStrings["DbStatisticsEntities"].ProviderName = "System.Data.EntityClient";
	config.Save();
	ConfigurationManager.RefreshSection("connectionStrings");
	Properties.Settings.Default.Save();
	Properties.Settings.Default.Reload();
