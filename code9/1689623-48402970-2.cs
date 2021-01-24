        class FileLoader
        {
            List<MyClass> myClassList = new List<MyClass>();
            public FileLoader()
            {
                if (File.Exists("texter.txt"))
                {
                    List<string[]> vectors = new List<string[]>();
                    StreamReader reader = new StreamReader("texter.txt", Encoding.Default, true);
                    for (string item = reader.ReadLine(); item != null; item = reader.ReadLine())
                    {
                        string[] vektor = item.Split(new string[] { "###" }, StringSplitOptions.RemoveEmptyEntries).Select(x=> x.Trim()).ToArray();
                        vectors.Add(vektor);
                        MyClass newClass = new MyClass();
                        myClassList.Add(newClass);
                        newClass.title = vektor[0];
                        newClass.type = vektor[1];
                    }
                   
                }
            }
        }
        public class MyClass
        {
            public string title { get; set; }
            public string type { get; set; }
        }
