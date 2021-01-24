    //using System.Linq;
    public void ApplyMaxLengthToTextBox(TextBox txt)
    {
        var binding = txt.DataBindings["Text"];
        if (binding == null)
            return;
        var bindingManager = binding.BindingManagerBase;
        var datasourceProperty = binding.BindingMemberInfo.BindingField;
        var propertyDescriptor = bindingManager.GetItemProperties()[datasourceProperty];
        var maxLengthAttribute = propertyDescriptor.Attributes.Cast<Attribute>()
            .OfType<MaxLengthAttribute>().FirstOrDefault();
        if (maxLengthAttribute != null)
            txt.MaxLength = maxLengthAttribute.Length;
    }
