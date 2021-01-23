       Z.RemoveAt(0); // let's remove the 1st item    
       Z.RemoveAll(pair => pair.Item2 < 5); // let's remove all y < 5 items
       // Let's have Y with 1st item deleted and all items < 5 removed
       int[] Ys = Z
         .Select(item => item.Item2)
         .ToArray();
