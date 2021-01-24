    class MyBuild
	{
		string _proj;
		string _target;
		bool _result;
		
		public MyBuild(string proj, string target)
		{
			_proj = proj;
			_target= target;
		}
		
		public bool Result {get{return _result;}}
		
		public void Start() 
		{
			Engine engine = new Engine();
		    engine.RegisterLogger(new ConsoleLogger());
		    _result = engine.BuildProjectFile(_proj, _target);
		}
	}
