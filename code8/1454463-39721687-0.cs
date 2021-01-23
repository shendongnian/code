    class TextureProvider
    {
        public TextureProvider()
        {
        }
        public void Foo()
        {
        }
    }
    class SpecialTextureProvider : TextureProvider
    {
        public SpecialTextureProvider()
            : base()
        {
        }
    }
    class BaseLayer<TP> where TP : TextureProvider, new()
    {
        public BaseLayer()
        {
            var tp = new TP();
        }
    }
    class SpecificLayer : BaseLayer<SpecialTextureProvider>
    {
    }
