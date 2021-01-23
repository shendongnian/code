    public string GetStringBody() {
    	System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
    	string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    	var di = new DirectoryInfo(path);
    	return di.Parent.Parent.Parent.FullName; // here you should define how many level you want to up
    }
