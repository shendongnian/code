    class typeObj
    {
    	public int num {get; set; }
    	public List<metatypes> meta {get; set;}
    }
    
    class metatypes
    {
    	public int id {get; set;}
    	public idtypes identif {get; set;}
    }
    class idtypes
    {
    	public bool type {get; set;}
    	public bool status {get; set;}
    }
