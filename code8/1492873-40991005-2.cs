        private IList readObjects(Type objType)
        {
            // rest of code with Activator and so on
        }
    And later usage depends on your needs.
    If you know what type you going to use, simply convert:
        var list = (IList<MyType>)readObjects(typeof(myType));
    But I guess in that case better use way #1 with generic argument.
    Otherwise you going to use reflection. Or some base classes, interfaces and so on. It depends on what exactly task you going to solve. 
        
