    public class MyGameObject : GameObject{
	
	   public MyGameObject() : base(){
	
		   Console.WriteLine("Calls constructor from base class and this!");
	   }
	
	   public string MyPath {get; set;}
    }
