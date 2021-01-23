    var customBindingElement = new CustomTextMessageBindingElement("UTF-8", "text/xml", MessageVersion.Soap11);
    var binding = new CustomBinding(basicBinding);
    binding.Elements.RemoveAt(0);
    binding.Elements.Insert(0, customBindingElement);
    var client = (T2)Activator.CreateInstance(typeof(T), binding, address);
