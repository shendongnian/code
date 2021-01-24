    class A {public int id; public string name; public string type;public  List<B> listB; }
    class B { public int id;public  int refid; public string value; }
    static void Main(string[] args)
    {
       List<A> ListofA = new List<A>{
    	   new A() { id = 1,name = "ABC",type = "A",listB = null},
    	   new A() { id = 2,name = "XYZ",type = "A",listB = null}
       };
    
    	List<B> listOfB = new List<B>{
    		new B() { id =4,refid=1,value="ABC"},
    		new B() { id=5,refid=1,value="DEF"},
    		new B() { id=6,refid=2,value="XYZ"}}         ;
    
    	var ListofA2 = ListofA.Select(a => new A
    		{
    			id = a.id,
    			name = a.name,
    			type = a.type,
    			listB = listOfB.Where(b => b.refid == a.id).ToList()
    		}
    	).ToList();
    }
