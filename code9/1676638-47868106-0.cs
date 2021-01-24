    public static class MarkupExtensionHost
    {
        public static IUnityContainer Container { get; set; }
    }
    public class UnityContainerExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return MarkupExtensionHost.Container;
        }
    }
