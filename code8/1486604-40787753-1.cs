    public class GlobalTransformer : ITransformer
    {
         private readonly IList<ITransformer> _availableTransformers;
         public GlobalTransformer(IList<ITransformer> availableTransformers)
         {
             _availableTransformers = _availableTransformers;
         }
         public List<MyClass> override Transform(MyClass item) {
            List<MyClass> result = new List<MyClass>();
            foreach (var item in _availableTransformers) {
               result.AddRange(item.Transform(item));
            }
            return result;
         }
    }
