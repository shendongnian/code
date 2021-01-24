    var fieldInfo = mainControl.GetType().GetField("CustomControl", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    var valueOfField = fieldInfo.GetValue(mainControl);
    var customControlType = typeof(CustomControl);
    var methodInfo = customControlType.GetMethod("Display");
    methodInfo.Invoke(valueOfField, new object[] {});
