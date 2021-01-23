    abstract class SceneObject : IVisitorClient
    {
        public virtual void Accept(IVisitor visitor)
        {
             visitor.Visit(this);
        }
    }
    class Portal : SceneObject
    {
    ...
        public override void Accept(IVisitor visitor)
        {
             visitor.Visit(this);
        }
    ...
    }
    class Enemy: SceneObject
    {
    ...
        public override void Accept(IVisitor visitor)
        {
             visitor.Visit(this);
        }
    ...
    }
