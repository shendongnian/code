    public class DisplayExtension : IMarkupExtension<string>
    {
      public BindingBase Target { get; set; }
      BindableProperty _Property;
      public string ProvideValue(IServiceProvider serviceProvider)
      {
        if (!(Target is Binding binding) || string.IsNullOrWhiteSpace(binding.Path))
          throw new InvalidOperationException($"'{nameof(Target)}' must be properly set.");
        var pvt = (IProvideValueTarget)serviceProvider
          .GetService(typeof(IProvideValueTarget));
        if (!(pvt.TargetObject is BindableObject bo
          && pvt.TargetProperty is BindableProperty bp
          && bp.ReturnType.GetTypeInfo()
              .IsAssignableFrom(typeof(string).GetTypeInfo())))
          throw new InvalidOperationException(
            $"'{nameof(DisplayExtension)}" +
            "' cannot only be applied to bindable string properties.");
        _Property = bp;
        bo.BindingContextChanged += DisplayExtension_BindingContextChanged;
        return null;
      }
      void DisplayExtension_BindingContextChanged(object sender, EventArgs e)
      {
        var bo = (BindableObject)sender;
        bo.BindingContextChanged -= DisplayExtension_BindingContextChanged;
        var display = ExtractMember(bo, (Binding)Target);
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
        var display = info.GetCustomAttribute<DisplayAttribute>();
        if (display != null)
          return display.Description;
        else
          return info.Name;
      }
      object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) =>
        ProvideValue(serviceProvider);
    }
