    public class MyClass
    {
        public void Init()
        {
            Type type = typeof(ClassThatIAmReflecting);
            FieldInfo fieldInfo = type.GetField("OnSuccess", BindingFlags.Public | BindingFlags.Static);
            var fieldType = fieldInfo.FieldType;
            
            var methodInfo = this.GetType().GetMethod("HandleOnSuccess", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var del = Delegate.CreateDelegate(fieldType, this, methodInfo);
            fieldInfo.SetValue(null, del);
            //test
            ClassThatIAmReflecting.OnSuccess(true);
        }
        private void HandleOnSuccess(bool value)
        {
            Console.WriteLine("Called");
        }
    }
