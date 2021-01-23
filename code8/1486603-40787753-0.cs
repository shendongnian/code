    public class GlobalTransformer : ITransformer
    {
         private readonly IList<ITransformer> _availableTransformers;
         public GlobalTransformer(IList<ITransformer> availableTransformers)
         {
             _availableTransformers = _availableTransformers;
         }
         public void override Transform() {
            foreach (var item in _availableTransformers) {
               item.Transform();
            }
         }
    }
