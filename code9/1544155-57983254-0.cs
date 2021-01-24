            class Console
            {
                public static Queue<string> TestData = new Queue<string>();
                public static void SetTestData(string testData)
                {
                    TestData = new Queue<string>(testData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(x=>x.TrimStart()));
                }
                public static void SetTestDataFromFile(string path)
                {
                    TestData = new Queue<string>(File.ReadAllLines(path));
                }
                public static string ReadLine()
                {
                    return TestData.Dequeue();
                }
                public static void WriteLine(object value = null)
                {
                    System.Console.WriteLine(value);
                }
                public static void Write(object value = null)
                {
                    System.Console.WriteLine(value);
                }
            }
