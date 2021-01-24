        static void Main(string[] args)
        {
            Program p = new Program();
            var result =  p.GetStartedDemo();
            foreach (var group in result)
            {
                Console.WriteLine("Group: " + group.Key);
                foreach (Login login in group)
                   Console.WriteLine("    " + login.SomeProperty); // print something from the login object.
            }
        }
