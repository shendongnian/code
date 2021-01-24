    publicstring GetHyperlinkAttributes<TEntity>(string name)
    {
         PropertyInfo property = typeof(TEntity).GetProperty(name);
         object[] attributes = property.GetCustomAttributes(false);
    
         var collection = new List<string>();
         foreach(Attribute attribute in attributes)
         {
              var hyperlink = attribute as HyperlinkAttribute;
              if(!string.IsNullOrEmpty(hyperlink?.Target)
                   return hyperlink.Target;
         }
    
         return String.Empty;
    }
