    void Main()
    {
    //Let this Table
    	List<SvrEnvApp> records = new List<SvrEnvApp>()
    	{
    		new SvrEnvApp(){
    		Server = "server1",
    		Env="FCT",
    		App="A"
    		},
    		new SvrEnvApp(){
    		Server = "server1",
    		Env="UAT",
    		App="B"
    		},
    		new SvrEnvApp(){
    		Server = "server2",
    		Env="FCT",
    		App="A"
    		},
    		new SvrEnvApp(){
    		Server = "server2",
    		Env="UAT",
    		App="B"
    		}	
    	};
    	
    	List<SvrEnvApp> result = records.GroupBy(o=> o.Server).Select(g=> new SvrEnvApp()
    	{
    		Server = g.Key,
    		Env= String.Join(",",g.Select(r=> r.Env)),
    		App= String.Join(",",g.Select(r=> r.App)),
    	}).ToList();
    	result.Dump();
    }
    
    public class SvrEnvApp
    {
     public string Server{get;set;}
     public string Env{get;set;}
     public string App{get;set;}
    }
