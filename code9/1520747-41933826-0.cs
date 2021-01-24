    System.Reflection.Assembly myAssembly = this.GetType().Assembly;
	string rexFile = ConfigurationManager.AppSettings["CuurentRexfile"];
	System.Reflection.Assembly otherAssembly = System.Reflection.Assembly.Load(rexFile);
	System.Resources.ResourceManager resManager = new System.Resources.ResourceManager("ResourceNamespace.myResources", otherAssembly);
	string test = resManager.GetString("resourceString");
