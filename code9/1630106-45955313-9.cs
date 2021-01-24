    public class Plugin
    {
        public int Test()
        {
            var testClass = typeof(Test);
            var testInstance = Activator.CreateInstance(testClass);
            var method = testClass.GetMethod("Method");
            int result = (int)method.Invoke(testInstance, new object[]{1, 2});
            return result;
        }
    }
