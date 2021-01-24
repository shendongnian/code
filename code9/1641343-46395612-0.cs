    public abstract class Item
    {
        public abstract Sprite Icon { get; }
        public abstract string Name { get; }
    }
    public class Stone : Item
    {
        private static readonly Sprite icon = Sprite.Create(/* parameters omitted */);
        private const string name = "Stone";
        // expression-bodied member: supported as of C# 6
        public override Sprite Icon => icon;
        // traditional propery getter
        public override string Name
        {
            get
            {
                return name;
            }
        }
    }
