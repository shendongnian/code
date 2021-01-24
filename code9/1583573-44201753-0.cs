    if (typeName.Equals(
                    "System.Lazy`1+Boxed[[System.Collections.ObjectModel.Collection`1[[ConsoleApplication14.MyInnerClass, ConsoleApplication14, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"))
    {
        return Type.GetType(typeName.Replace("ConsoleApplication14.MyInnerClass", "ConsoleApplication14.OtherNamespace.MyInnerClass"));
    }
