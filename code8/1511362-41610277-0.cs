    interface IVisitorClient
    {
        Accept(IVisitor visitor);
    }
    interface IVisitor
    {
        Visit(SceneObject o); // here the types of your objects
        Visit(Enemy e);
        Visit(Portal p);
    }
