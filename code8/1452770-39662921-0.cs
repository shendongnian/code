        [TestCase] // using nunit
        public void sometest()
        {
            int i = 0;
            Func<string, Task<string>> mockFunc = async s =>
            {
                i++; // count stuff
                await Task.Run(() => { Console.WriteLine("Awating stuff"); });
                return "Just return whatever";
            };
            var a = Repeater.RunCommandWithException(mockFunc, "mockString");
        }
