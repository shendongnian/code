     using System; 
        using System.Windows.Markup;
        using System.Windows.Media;
        using imbCore.resources;
    
        #endregion
    
        [MarkupExtensionReturnType(typeof (ImageSource))]
        public class imbImageSourceExtension : MarkupExtension
        {
            public imbImageSourceExtension()
            {
            }
    
            public imbImageSourceExtension(String imageName)
            {
                this.ImageName = imageName;
            }
    
            [ConstructorArgument("imageName")]
            public String ImageName { get; set; }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                try
                {
                    
                    if (imbCoreApplicationSettings.doDisableIconWorks) return null;
                    return imbIconWorks.getIconSource(ImageName);
                    
                }
                catch
                {
                    return null;
                }
            }
        }
