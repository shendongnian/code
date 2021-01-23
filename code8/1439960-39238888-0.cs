	private string ftp_fingerprint;
	private string ftp_host;
	private string ftp_username;
	private string ftp_pass;
	
	public Upload()
	{
		#region INI PROPERTIES and Variables
	
		INIFile inif = new INIFile(@".\Settings\AppSettings.ini");
		//Values for DatabaseManager dbm
		//Hosting Server IP
		string srv_ip = inif.Read("DatabaseSettings", "IP_adress");
		//Database Username
		string srv_uname = inif.Read("DatabaseSettings", "Admin_Username");
		//Database Password
		string srv_pass = inif.Read("DatabaseSettings", "Admin_Password");
		//Database Name
		string srv_dbname = inif.Read("DatabaseSettings", "Database_Name");
	
		//Values for DatabaseManager dbm
	
		//Fingerprint of Hosting Server IP
		ftp_fingerprint = inif.Read("ProgramSettings", "fingerprint");
		//Host
		ftp_host = inif.Read("ProgramSettings", "host");
		//Username
		ftp_username = inif.Read("ProgramSettings", "username");
		//Password
		ftp_pass = inif.Read("ProgramSettings", "password");
	
		#endregion
		InitializeComponent();
		DatabaseManager dbm = new DatabaseManager(srv_ip, srv_uname, srv_pass, srv_dbname);
		dbm.Init();
	}
	
	private void upload_btn_MouseDown(object sender, MouseButtonEventArgs e)
	{
	
		string fingerprint = ftp_fingerprint;
		string host = ftp_host;
		string username = ftp_username;
		string password = ftp_pass;
	
		FtpManager ftpm = new FtpManager(host, username, password, fingerprint, ProgressCallback);
	
		string remoteFolder = "/var/whatever"; // Name of directory to upload
		string remoteName;    // Name of file to save on server
	
		//some more code
	}
