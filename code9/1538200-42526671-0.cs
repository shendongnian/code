    using System.Reflection;
    ...
    var objects = new MyObjects();
    var propertyInfo = typeof(MyObjects).GetRuntimeProperty("RGP_IDREG_1");
    var value = (int)(propertyInfo.GetMethod.Invoke(objects, new object [] {}));
