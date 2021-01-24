    public class DisplayExtension : IMarkupExtension<string>
    {
      public object Target { get; set; }
      BindableProperty _Property;
      public string ProvideValue(IServiceProvider serviceProvider)
      {
        if (Target == null
          || !(Target is Binding binding && !string.IsNullOrWhiteSpace(binding.Path))
          || !(Target is Enum))
          throw new InvalidOperationException($"'{nameof(Target)}' must be properly set.");
        var p =(IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
        if (!(p.TargetObject is BindableObject bo
          && p.TargetProperty is BindableProperty bp
          && bp.ReturnType.GetTypeInfo().IsAssignableFrom(typeof(string).GetTypeInfo())))
          throw new InvalidOperationException(
            $"'{nameof(DisplayExtension)}' cannot only be applied"
              + "to bindable string properties.");
        _Property = bp;
        bo.BindingContextChanged += DisplayExtension_BindingContextChanged;
        return null;
      }
      void DisplayExtension_BindingContextChanged(object sender, EventArgs e)
      {
        var bo = (BindableObject)sender;
        bo.BindingContextChanged -= DisplayExtension_BindingContextChanged;
        string display = null;
        if (Target is Binding binding)
          display = ExtractMember(bo, (Binding)Target);
        else if (Target is Type type)
          display = ExtractDescription(type.GetTypeInfo());
        else if (Target is Enum en)
        {
          var enumType = en.GetType();
          if (!Enum.IsDefined(enumType, en))
            throw new InvalidOperationException(
              $"The value '{en}' is not defined in '{enumType}'.");
          display = ExtractDescription(
            enumType.GetTypeInfo().GetDeclaredField(en.ToString()));
        }
        bo.SetValue(_Property, display);
      }
      string ExtractMember(BindableObject target, Binding binding)
      {
        var container = target.BindingContext;
        var properties = binding.Path.Split('.');
        var i = 0;
        do
        {
          var property = properties[i++];
          var type = container.GetType();
          var info = type.GetRuntimeProperty(property);
          if (properties.Length > i)
            container = info.GetValue(container);
          else
          {
            return ExtractDescription(info);
          }
        } while (true);
      }
      string ExtractDescription(MemberInfo info)
      {
        var display = info.GetCustomAttribute<DisplayAttribute>(true);
        if (display != null)
          return display.Name ?? display.Description;
        var description = info.GetCustomAttribute<DescriptionAttribute>(true);
        if (description != null)
          return description.Description;
        return info.Name;
      }
      object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) =>
        ProvideValue(serviceProvider);
    }
