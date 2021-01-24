    using System; 
        using System.Windows;
        using System.Windows.Markup;
    
        #endregion
    
        /// <summary>
        /// Pristup glavnom registru resursa
        /// </summary>
        [MarkupExtensionReturnType(typeof (ResourceDictionary))]
        public class masterResourceExtension : MarkupExtension
        {
            public masterResourceExtension()
            {
            }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                try
                {
                    return imbXamlResourceManager.current.masterResourceDictionary;
                }
                catch
                {
                    return null;
                }
            }
        }
