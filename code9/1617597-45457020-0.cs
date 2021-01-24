    //Declare your player list inside your form
    private List<Player> players = new List<Player>();
    
    //Make player a CLASS
    public class Player
    {
    	public string name { get; set; }
    	public System.Drawing.Color color { get; set; }
    
    	//Declare your class CONSTRUCTOR, like this
    	public Player(string name, System.Drawing.Color color)
    	{
    		this.name = name;
    		this.color = color;
    	}
    }
    
    //NOW, this will work
    public void playergenerator(string myname, System.Drawing.Color myColor)
    {
    	players.Add(new Player(myname, myColor));
    }
