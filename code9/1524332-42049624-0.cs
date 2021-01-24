    public static class Foo
    {
        public static void DoSomething()
        {
            string someText = "someText";
            using (StreamWriter writer = new StreamWriter("myfile.txt"))
            {
                writer.Write(someText);
                writer.Close();
                writer.Dispose();
            }
        }
    }
