    public class BaseMaster
    {
        public ReadOnlyCollection<BaseChild> Children { get; }
    }
    public class BaseMaster<T> : BaseMaster where T: BaseChild
    {
        public new IEnumerable<T> Children { get
            {
               return base.Children.Cast<T>();
            };
        }
    }
