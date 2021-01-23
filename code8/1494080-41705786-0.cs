    public class MyControl : Control
    {
        public MyControl()
        {
            ApplyDefaultStyle();
        }
        protected void ApplyDefaultStyle()
        {
            this.Style = WpfHelpers.GetDefaultStyle(this.GetType(), "OwnResourceDictionaryFullPath here");
            this.ApplyTemplate();
        }
    }
    public static class WpfHelpers
    {
        /// <summary>
        /// Extracts the control's default Style from the resource dictionary pointed by the <see cref="resourceFullPath"/>.
        /// So the Style without x:Key, with TargetType <see cref="controlType"/>
        /// </summary>
        public static Style GetDefaultStyle(Type controlType, string resourceFullPath)
        {
            Uri resourceLocater = null;
            string assemblyName = null;
            try
            {
                assemblyName = controlType.Assembly.GetName().Name;
                resourceLocater = new Uri($"/{assemblyName};component/{resourceFullPath}", UriKind.Relative);
                var resourceDictionary = (ResourceDictionary)Application.LoadComponent(resourceLocater);
                var style = resourceDictionary[controlType] as Style;
                return style;
            }
            catch(Exception e)
            {
                //Log.Warn
                return null;
            }
        }
    }
