     var gameObject = new GameObject();
     var types = new List<string>() { "a", "b", "c" };
     var newObjects = types.Select(t => (IGameManager)gameObject.AddComponent(t));
    // at this point, nothing has happened....
     Console.WriteLine(gameObject.Components.Count());  // 0
     Console.WriteLine(newObjects.Count());   // 3 - we trigger the selects
     Console.WriteLine(gameObject.Components.Count()); // 3
     Console.WriteLine(newObjects.Count()); // 3 - we trigger the selects again
     Console.WriteLine(gameObject.Components.Count());  // 6
