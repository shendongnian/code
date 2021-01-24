    namespace ClassLibrary1
    {
        public class Class1
        {
            public static Stream GetImage()
            {
                var assembly = typeof(Class1).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("ClassLibrary1.Assets.dog.jpg");
                return stream;
            }
        }
    }
