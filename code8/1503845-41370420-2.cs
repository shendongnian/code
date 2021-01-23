        public class FilterActionCollection : ConfigurationElementCollection
        {       
           protected override ConfigurationElement CreateNewElement()
           {  return new FilterAction();}
        protected override object GetElementKey(ConfigurationElement element)
           {  return ((FilterAction) element).Type;}
       }
