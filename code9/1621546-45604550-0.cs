    public class CustomObject
    {
    	//properties that represent the state, direction, inventory, etc.
    	public string Direction{get;set;}//etc.
    }
    
    public interface ICommand
    {
    	string Execute(CustomObject obj);
    }
    
    public class InventoryCommand: ICommand
    {
    	public string Execute(CustomObject obj)
    	{
    		//code to create the inventory string from CustomObject
    		return "Inventory String";
    	}
    }
    
    public class NorthCommand: ICommand
    {
    	public string Execute(CustomObject obj)
    	{
    		//code to move the object to north
    		return "Command Information";
    	}
    }
    
    
    //In your test cases, you can do
    
    CustomObject obj = new CustomObject();
    //test for inventory command
    var expectedOutput = "Expected Output";
    var result = (new InventoryCommand()).Execute(obj);
    Assert.Equal(result, expectedOuput);
    
    //In your console program
    if(command == "help")
    {  
    	Console.Writeline((new HelpCommand()).Execute(obj)); 
    }
    else if (command.Contains == "inv")
    {  
    	Console.Writeline((new InventoryCommand()).Execute(obj)); 
    )
