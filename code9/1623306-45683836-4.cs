    public class BaseTemplate<T> where T : new()
    {
        static BaseTemplate()
        {
            Console.WriteLine("BaseTemplate() " + typeof(T).Name);
        }
        public static object Factory = new object();
        public static void Render()
        {
            Console.WriteLine("Render() from BaseTemplate, " + typeof(T).Name);
        }
    }
    public class Template : BaseTemplate<Template>
    {
        static Template()
        {
            Console.WriteLine("Static ctor()");
        }
        public static new void Render()
        {
            Console.WriteLine("Render() from Template.");
            BaseTemplate<Template>.Render();
        }
    }
    public class Template2 : BaseTemplate<Template2>
    {
        static Template2()
        {
            Console.WriteLine("Static ctor() 2");
        }
        public static new void Render()
        {
            Console.WriteLine("Render() from Template2.");
            BaseTemplate<Template2>.Render();
        }
    }
