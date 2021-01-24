    public class App : MvxApplication
    {
        public override void Initialize()
        {
            /* Other registerations*/
    
            Mvx.LazyConstructAndRegisterSingleton<ISharedShoppingCart, SharedShoppingCart>();
        }
    }
