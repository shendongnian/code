    abstract class ToolType // I've used an abstract class here, but you can use interfaces or normal classes.
    {
        public virtual void Test()
        {
            Console.WriteLine("Base");
        }
    }
    [Export(typeof(ToolType)), PartCreationPolicy(CreationPolicy.NonShared)] // Part creation policy is for your lifetime management. NonShared is instanced and Shared would be like a singleton.
    class Brush : ToolType
    {
        public override void Test()
        {
            Console.WriteLine("Brush");
        }
    }
    [Export(typeof(ToolType)), PartCreationPolicy(CreationPolicy.NonShared)]
    class Eraser : ToolType
    {
        public override void Test()
        {
            Console.WriteLine("Eraser");
        }
    }
    [Export(typeof(ToolType)), PartCreationPolicy(CreationPolicy.NonShared)]
    class  Drag : ToolType
    {
        public override void Test()
        {
            Console.WriteLine("Drag");
        }
    }
