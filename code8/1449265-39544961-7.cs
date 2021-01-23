    private static string loadCode()
    {
        string namespaces = @"using MyTypesNamespace;";
        string rustyKeyClass = generateItemClass("RustyKey",
            @"var door = onMyObject as Door;
            return door.Open();");
        string unlockAnyDoorClass = generateItemClass("UnlockAnyDoor",
            @"var door = onMyObject as Door;
            door.IsLocked = false;
            System.Console.WriteLine(""Door is unlocked!"");
            return true;");
        return namespaces + rustyKeyClass + unlockAnyDoorClass;
    }
