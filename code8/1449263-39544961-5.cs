    private static void Main()
    {
        string code =  loadCode();
        List<BaseItem> items = loadItems(code);
    
        BaseItem rustyKey = items[0];
        BaseItem unlockAnyDoor = items[1];
    
        Door myDoor = new Door { IsLocked = true };
        rustyKey.Use(myDoor);
        unlockAnyDoor.Use(myDoor);
        rustyKey.Use(myDoor);
    
    
        Console.ReadLine();
    }
    
    private static string loadCode()
    {
        return @"
            using MyTypesNamespace;
            public class RustyKey : BaseItem
            {
                public override bool Use(object onMyObject)
                {
                    var door = onMyObject as Door;
    
                    return door.Open();
                }
            }
    
            public class UnlockAnyDoor : BaseItem
            {
                public override bool Use(object onMyObject)
                {
                    var door = onMyObject as Door;
                    door.IsLocked = false;
                    System.Console.WriteLine(""Door is unlocked!"");
                    return true;
                }
            }
    ";
    }
