    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo info, object value, Type destType) {
      if ((destType == typeof(string)) && (value is CustomButton)) {
        CustomButton bt = (CustomButton) value;
        return bt.Name;
      }
        
      // this helped me a lot
      // here the object needs to know how to create itself
      // Type[0] can be overridden by Type[] { (your constructor parameterTypes) }
      // null can be overridden by objects that will be passed how parameter
      // third parameter is a value indicating if the initialization of the object is or not complete
      else if (destType == typeof(InstanceDescriptor)) {
        return new InstanceDescriptor(
          typeof(CustomButton).GetConstructor(new Type[0]),
          null,
          false
        );
      }
      return base.ConvertTo(context, info, value, destType);
    }
