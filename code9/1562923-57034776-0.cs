    [ContentProperty(Name = nameof(Templates))]
    public class TypedDataTemplateSelector : DataTemplateSelector
    {
      public IList<TypedDataTemplate> Templates { get; } 
        = new ObservableCollection<TypedDataTemplate>();
      public TypedDataTemplateSelector()
      {
        var incc = (INotifyCollectionChanged)Templates;
        incc.CollectionChanged += (sender, e) =>
        {
          if (e?.NewItems.Cast<TypedDataTemplate>()
              .Any(tdt => tdt?.DataType == null || tdt?.Template == null) == true)
            throw new InvalidOperationException("All items must have all properties set.");
        };
      }
      protected override DataTemplate SelectTemplateCore(object item, 
          DependencyObject container)
      {
        if (item == null) return null;
        if (!Templates.Any()) throw new InvalidOperationException("No DataTemplates found.");
        var result =
          Templates.FirstOrDefault(t => t.DataType.IsAssignableFrom(item.GetType()));
        if (result == null)
          throw new ArgumentOutOfRangeException(
            $"Could not find a matching template for type '{item.GetType()}'.");
        return result.Template;
      }
    }
    [ContentProperty(Name = nameof(Template))]
    public class TypedDataTemplate
    {
      public Type DataType { get; set; }
      public DataTemplate Template { get; set; }
    }
